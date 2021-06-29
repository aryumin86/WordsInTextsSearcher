using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WordsInTextsSearcher.Entities;

namespace WordsInTextsSearcher.Repos
{
    public interface IProjectsRepo
    {
        public Project GetProject(int id);
        public void DeleteProject(int id);
        public Project CreateProject(Project project);
        public Project UpdateProject(Project project);
        public IEnumerable<Project> GetProjects(Expression<Func<Project, bool>> predicate);
    }
}
