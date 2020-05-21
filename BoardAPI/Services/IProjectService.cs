using BoardAPI.Models.ProjectsModels;
using BoardAPI.Services.Communication;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BoardAPI.Services
{
    public interface IProjectService
    {
        Task<IEnumerable<Project>> ListAsync();
        Task<ProjectResponse> SaveAsync(Project project);
        Task<ColumnResponse> SaveAsyncColumn(Column column, int ProjectID);
        Task<TaskResponse> SaveAsyncTask(Models.ProjectsModels.Task task, int ColumnID, int ProjectID);

        Task<Project> FindByIDAsync(int ID);
        Task<ProjectResponse> DeleteAsync(int ID);
        int CountOfStockData();
        bool IsDbEmpty();
        bool SpecificProjectDataExists(int ID);
        ProjectResponse Update(Project project);
    }
}
