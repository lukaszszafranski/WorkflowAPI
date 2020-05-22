﻿using BoardAPI.Models.ProjectsModels;
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
        System.Threading.Tasks.Task RemoveColumn(int projectID, int columnID);
        System.Threading.Tasks.Task RemoveTask(int id, int columnID, int taskID);
        void UpdateColumn(Column editProject, int projectID, int columnID);
        void UpdateTask(Models.ProjectsModels.Task editProject, int id, int columnID, int taskID);
    }
}
