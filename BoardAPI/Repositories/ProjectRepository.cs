using BoardAPI.Data;
using BoardAPI.Helpers;
using BoardAPI.Models.ProjectsModels;
using BoardAPI.Repositories.Persistence;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoardAPI.Repositories
{
    public class ProjectRepository : BaseRepository, IProjectRepository
    {
        private new BoardAPIContext _context;

        public ProjectRepository(BoardAPIContext context) : base(context)
        {
            _context = context;
        }
        public async Task AddAsync(Project project)
        {
            await _context.Projects.AddAsync(project);
        }

        public int CountOfProjectData()
        {
            return _context.Projects.ToList().Count();
        }

        public async Task<Project> FindByIDAsync(int ID)
        {
            return await Task.Run(() => _context.Projects.Where(p => p.ProjectID == ID).ElementAt(0));
        }

        public bool IsDbEmpty()
        {
            return !_context.Projects.Any();
        }

        public async Task<IEnumerable<Project>> ListAsync()
        {
            return await Task.Run(() => _context.Projects.ToList());
        }

        public void Remove(Project project)
        {
            _context.Projects.Remove(project);
        }

        public bool SpecificProjectExists(int ID)
        {
            return _context.Projects.Any(p => p.ProjectID == ID);
        }

        public void Update(Project projectParam)
        {
            var project = _context.Projects.Find(projectParam.ProjectID);

            if (project == null)
                throw new AppException("User not found");

            if (projectParam.Title != project.Title)
            {
                // project title has changed so check if the new username is already taken
                if (_context.Projects.Any(x => x.Title == projectParam.Title))
                    throw new AppException("Title " + projectParam.Title + " is already taken");
            }

            // update project properties
            project.Title = projectParam.Title;
            project.Status = projectParam.Status;
            project.VisibilityState = projectParam.VisibilityState;

            _context.Projects.Update(project);
            _context.SaveChanges();
        }
    }
}
