﻿/* 
 * Copyright (C) Work-FLow, All Rights Reserved
 * Unauthorized copying of this file, via any medium is strictly prohibited
 * Proprietary and confidential
 * Written by Łukasz Szafrański <lukasz.szafranski16@wp.pl>, Krzysztof Łepkowski, Szymon Lewandowski, May 2023
 */

using BoardAPI.Data;
using BoardAPI.Helpers;
using BoardAPI.Models.ProjectsModels;
using BoardAPI.Repositories.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoardAPI.Repositories
{
    public class ProjectRepository : BaseRepository, IProjectRepository
    {
        private new WorkflowAPIContext _context;

        public ProjectRepository(WorkflowAPIContext context) : base(context)
        {
            _context = context;
        }
        public async System.Threading.Tasks.Task AddAsync(Project project)
        {
            await _context.Projects.AddAsync(project);
        }

        public System.Threading.Tasks.Task AddColumnAsync(Column column, int ProjectID)
        {
            var project = _context.Projects.Include(x => x.Columns)
                                           .ThenInclude(y => y.Tasks)
                                           .Where(x => x.ProjectID == ProjectID)
                                           .ToList()
                                           .ElementAt(0);

            var listOfColumns = project.Columns.ToList();
            listOfColumns.Add(column);

            project.Columns = listOfColumns;            

            _context.Projects.Update(project);
            return System.Threading.Tasks.Task.Run(() => _context.SaveChanges());
        }

        public System.Threading.Tasks.Task AddTaskAsync(Models.ProjectsModels.Task task, int ProjectID, int ColumnID)
        {
            var project = _context.Projects.Include(x => x.Columns)
                                           .ThenInclude(y => y.Tasks)
                                           .Where(x => x.ProjectID == ProjectID)
                                           .ToList()
                                           .ElementAt(0);

            var column = project.Columns.Where(x => x.ColumnID == ColumnID).ToList().ElementAt(0);
            var listOfTasks = column.Tasks.ToList();
            listOfTasks.Add(task);

            var tasksInProject = project.Columns.Where(x => x.ColumnID == ColumnID).ToList().ElementAt(0);

            tasksInProject.Tasks = listOfTasks;

            _context.Projects.Update(project);
            return System.Threading.Tasks.Task.Run(() => _context.SaveChanges());
        }

        public int CountOfProjectData()
        {
            return _context.Projects.ToList().Count();
        }

        public async Task<Project> FindByIDAsync(int ID)
        {
            return await System.Threading.Tasks.Task.Run(() => _context.Projects.Include(x => x.Columns).ThenInclude(y => y.Tasks).Where(p => p.ProjectID == ID).ToList().ElementAt(0));
        }

        public bool IsDbEmpty()
        {
            return !_context.Projects.Any();
        }

        public async Task<IEnumerable<Project>> ListAsync()
        {
            return await System.Threading.Tasks.Task.Run(() => _context.Projects.Include(x => x.Columns).ThenInclude(y => y.Tasks).ToList());
        }

        public void Remove(Project project)
        {
            _context.Projects.Remove(project);
        }

        public System.Threading.Tasks.Task RemoveColumn(int projectID, int columnID)
        {
            var project = _context.Projects.Include(x => x.Columns)
                                           .ThenInclude(y => y.Tasks)
                                           .Where(x => x.ProjectID == projectID)
                                           .ToList()
                                           .ElementAt(0);

            var columnToRemove = project.Columns.Where(x => x.ColumnID == columnID).ToList().ElementAt(0);

            var listOfColumns = project.Columns.ToList();
            listOfColumns.Remove(columnToRemove);

            project.Columns = listOfColumns;

            _context.Projects.Update(project);
            return System.Threading.Tasks.Task.Run(() => _context.SaveChanges());
        }

        public System.Threading.Tasks.Task RemoveTask(int id, int columnID, int taskID)
        {
            var project = _context.Projects.Include(x => x.Columns)
                                                       .ThenInclude(y => y.Tasks)
                                                       .Where(x => x.ProjectID == id)
                                                       .ToList()
                                                       .ElementAt(0);

            var column = project.Columns.Where(x => x.ColumnID == columnID).ToList().ElementAt(0);
            var listOfTasks = column.Tasks.ToList();

            var taskByIDFromColumn = column.Tasks.Where(x => x.TaskID == taskID).ToList().ElementAt(0);
            listOfTasks.Remove(taskByIDFromColumn);

            var tasksInProject = project.Columns.Where(x => x.ColumnID == columnID).ToList().ElementAt(0);

            tasksInProject.Tasks = listOfTasks;

            _context.Projects.Update(project);
            return System.Threading.Tasks.Task.Run(() => _context.SaveChanges());
        }

        public bool SpecificProjectExists(int ID)
        {
            return _context.Projects.Any(p => p.ProjectID == ID);
        }

        public void Update(Project projectParam)
        {
            var project = _context.Projects.Find(projectParam.ProjectID);

            if (project == null)
                throw new AppException("Project not found");

            if (projectParam.Title != project.Title)
            {
                // project title has changed so check if the new title is already taken
                if (_context.Projects.Any(x => x.Title == projectParam.Title))
                    throw new AppException("Title " + projectParam.Title + " is already taken");
            }

            // update project properties
            project.Title = projectParam.Title;

            _context.Projects.Update(project);
            _context.SaveChanges();
        }

        public void UpdateColumn(Column editColumn, int projectID, int columnID)
        {
            var project = FindByIDAsync(projectID).Result;
            var columnWithID = project.Columns.Where(x => x.ColumnID == columnID).ToList().ElementAt(0);

            if (project == null)
                throw new AppException("Project not found");

            // update project properties
            columnWithID.ColumnName = editColumn.ColumnName;

            _context.Projects.Update(project);
            _context.SaveChanges();
        }

        public void UpdateTask(Models.ProjectsModels.Task editTask, int id, int columnID, int taskID)
        {
            var project = _context.Projects.Find(id);
            var columnWithID = project.Columns.Where(x => x.ColumnID == columnID).ToList().ElementAt(0);
            var taskWithID = columnWithID.Tasks.Where(x => x.TaskID == taskID).ToList().ElementAt(0);

            if (project == null)
                throw new AppException("Project not found");

            // update project properties
            taskWithID.Name = editTask.Name;

            _context.Projects.Update(project);
            _context.SaveChanges();
        }
    }
}
