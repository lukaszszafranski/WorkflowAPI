using BoardAPI.Models.ProjectsModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BoardAPI.Repositories
{
    public interface IProjectRepository
    {
        Task<IEnumerable<Project>> ListAsync();
        System.Threading.Tasks.Task AddAsync(Project project);
        System.Threading.Tasks.Task AddColumnAsync(Column column, int ProjectID);
        System.Threading.Tasks.Task AddTaskAsync(Models.ProjectsModels.Task task, int ColumnID, int ProjectID);

        Task<Project> FindByIDAsync(int ID);
        int CountOfProjectData();
        void Remove(Project project);
        bool IsDbEmpty();
        bool SpecificProjectExists(int ID);
        void Update(Project project);

    }
}
