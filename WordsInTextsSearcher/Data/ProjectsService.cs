using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WordsInTextsSearcher.Entities;
using WordsInTextsSearcher.Repos;

namespace WordsInTextsSearcher.Data
{
    public class ProjectsService
    {
        private IProjectsRepo _projectsRepo;

        private Project _currentProject;
        public event Action OnCurrentProjectChanged;
        public Project CurrentProject
        {
            get
            {
                return _currentProject;
            }
            set
            {
                _currentProject = value;
                OnCurrentProjectChanged?.Invoke();
            }
        }

        public ProjectsService(IProjectsRepo projectsRepo)
        {
            _projectsRepo = projectsRepo;
        }

        public async Task<Project> CreateProject(Project project)
        {
            return await Task.FromResult(_projectsRepo.CreateProject(project));
        }

        public async Task<Project> UpdateProject(Project project)
        {
            return await Task.FromResult(_projectsRepo.UpdateProject(project));
        }

        public async Task DeleteProject(int id)
        {
            await Task.CompletedTask;
            _projectsRepo.DeleteProject(id);
        }

        public async Task<Project> GetProject(int id)
        {
            return await Task.FromResult(_projectsRepo.GetProject(id));
        }

        public async Task<IEnumerable<Project>> GetProjects(Expression<Func<Project, bool>> predicate)
        {
            return await Task.FromResult(_projectsRepo.GetProjects(predicate));
        }
    }
}
