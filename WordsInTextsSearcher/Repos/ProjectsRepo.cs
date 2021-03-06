using log4net.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WordsInTextsSearcher.Entities;

namespace WordsInTextsSearcher.Repos
{
    public class ProjectsRepo : IProjectsRepo
    {
        private SearcherDbContext _searcherDbContext;
        private ILogger<ProjectsRepo> _logger;

        public ProjectsRepo(SearcherDbContext searcherDbContext, ILogger<ProjectsRepo> logger)
        {
            _searcherDbContext = searcherDbContext;
            _logger = logger;
        }

        public Project CreateProject(Project project)
        {
            if(_searcherDbContext.Projects
                .Any(p => p.Title == project.Title))
            {
                throw new ArgumentException("Project with this name already exists");
            }

            project.WhenCreated = DateTime.Now;
            _searcherDbContext.Projects.Add(project);
            _searcherDbContext.SaveChanges();

            return project;
        }

        public void DeleteProject(int id)
        {
            var texts = _searcherDbContext.TextRecords.Where(x => x.ProjectId == id);
            var tags = _searcherDbContext.Tags.Where(x => x.ProjectId == id);
            var words = _searcherDbContext.Words.Where(x => x.ProjectId == id);
            var wordsIds = words.Select(w => w.Id);
            var wordForms = _searcherDbContext.WordForms.Where(x => wordsIds.Contains(x.WordId));
            var proj = _searcherDbContext.Projects.Find(id);

            _searcherDbContext.WordForms.RemoveRange(wordForms);
            _searcherDbContext.Words.RemoveRange(words);
            _searcherDbContext.TextRecords.RemoveRange(texts);
            _searcherDbContext.Tags.RemoveRange(tags);
            _searcherDbContext.Projects.Remove(proj);

            _searcherDbContext.SaveChanges();
        }

        public Project GetProject(int id)
        {
            return _searcherDbContext.Projects.Find(id);
        }

        public IEnumerable<Project> GetProjects(Expression<Func<Project, bool>> predicate)
        {
            return _searcherDbContext.Projects.Where(predicate);
        }

        public Project UpdateProject(Project project)
        {
            _searcherDbContext.Projects.Update(project);
            _searcherDbContext.SaveChanges();
            return project;
        }
    }
}
