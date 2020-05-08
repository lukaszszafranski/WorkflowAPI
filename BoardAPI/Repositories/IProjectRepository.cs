using BoardAPI.Models.ProjectsModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BoardAPI.Repositories
{
    public interface IProjectRepository
    {
        Task<IEnumerable<Project>> ListAsync();
        Task AddAsync(Project project);
        Task<Project> FindByIDAsync(int ID);
        int CountOfProjectData();
        void Remove(Project project);
        bool IsDbEmpty();
        bool SpecificProjectExists(int ID);
        void Update(Project project);

    }
}
