using BoardAPI.Models.ProjectsModels;
using BoardAPI.Repositories;
using BoardAPI.Repositories.Domain;
using BoardAPI.Services.Communication;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BoardAPI.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ProjectService(IProjectRepository projectRepository, IUnitOfWork unitOfWork)
        {
            _projectRepository = projectRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<Project>> ListAsync()
        {
            return await _projectRepository.ListAsync();
        }
        public async Task<ProjectResponse> SaveAsync(Project projectData)
        {
            try
            {
                await _projectRepository.AddAsync(projectData);
                await _unitOfWork.CompleteAsync();

                return new ProjectResponse(projectData);
            }
            catch (Exception ex)
            {
                return new ProjectResponse($"An error occurred when saving the category: {ex.Message}");
            }
        }
        public async Task<Project> FindByIDAsync(int ID)
        {
            return await _projectRepository.FindByIDAsync(ID);
        }
        public async Task<ProjectResponse> DeleteAsync(int ID)
        {
            var existingProjectData = await _projectRepository.FindByIDAsync(ID);

            if (existingProjectData == null)
            {
                return new ProjectResponse("Project not found");
            }

            try
            {
                _projectRepository.Remove(existingProjectData);
                await _unitOfWork.CompleteAsync();

                return new ProjectResponse(existingProjectData);
            }
            catch (Exception ex)
            {
                return new ProjectResponse($"An error occurred when deleting the category: {ex.Message}");
            }
        }
        public bool IsDbEmpty()
        {
            return _projectRepository.IsDbEmpty();
        }
        public bool SpecificProjectDataExists(int ID)
        {
            return _projectRepository.SpecificProjectExists(ID);
        }

        public int CountOfStockData()
        {
            return _projectRepository.CountOfProjectData();
        }

        public ProjectResponse Update(Project project)
        {
            _projectRepository.Update(project);

            return new ProjectResponse("Project was updated");
        }

        public async Task<ColumnResponse> SaveAsyncColumn(Column column, int ProjectID)
        {
            try
            {
                await _projectRepository.AddColumnAsync(column, ProjectID);
                await _unitOfWork.CompleteAsync();

                return new ColumnResponse(column);
            }
            catch (Exception ex)
            {
                return new ColumnResponse($"An error occurred when saving the category: {ex.Message}");
            }
        }

        public async Task<TaskResponse> SaveAsyncTask(Models.ProjectsModels.Task task, int ColumnID, int ProjectID)
        {
            try
            {
                await _projectRepository.AddTaskAsync(task, ColumnID, ProjectID);
                await _unitOfWork.CompleteAsync();
                return new TaskResponse(task);
            }
            catch (Exception ex)
            {
                return new TaskResponse($"An error occurred when saving the category: {ex.Message}");
            }   
        }

        public async Task<ColumnResponse> DeleteColumnAsync(int id, int columnID)
        {
            var existingProjectData = await _projectRepository.FindByIDAsync(id);

            if (existingProjectData == null)
            {
                return new ColumnResponse("Project not found");
            }

            try
            {
                await _projectRepository.RemoveColumn(id, columnID);
                await _unitOfWork.CompleteAsync();

                return new ColumnResponse("Column was removed!");
            }
            catch (Exception ex)
            {
                return new ColumnResponse($"An error occurred when deleting the category: {ex.Message}");
            }
        }

        public async Task<TaskResponse> DeleteTaskAsync(int id, int columnID, int taskID)
        {
            var existingProjectData = await _projectRepository.FindByIDAsync(id);

            if (existingProjectData == null)
            {
                return new TaskResponse("Project not found");
            }

            try
            {
                await _projectRepository.RemoveTask(id, columnID, taskID);
                await _unitOfWork.CompleteAsync();

                return new TaskResponse("Task was removed!");
            }
            catch (Exception ex)
            {
                return new TaskResponse($"An error occurred when deleting the category: {ex.Message}");
            }
        }

        public ColumnResponse UpdateColumn(Column editColumn, int columnID, int projectID)
        {
            _projectRepository.UpdateColumn(editColumn, projectID, columnID);

            return new ColumnResponse("Column was updated");
        }

        public TaskResponse UpdateTask(Models.ProjectsModels.Task editTask, int id, int columnID, int taskID)
        {
            _projectRepository.UpdateTask(editTask, id, columnID, taskID);

            return new TaskResponse("Task was updated");
        }
    }
}
