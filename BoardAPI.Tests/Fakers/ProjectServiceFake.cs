using BoardAPI.Helpers;
using BoardAPI.Models.ProjectsModels;
using BoardAPI.Services;
using BoardAPI.Services.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkflowAPI.Tests.Fakers
{
    public class ProjectServiceFake : IProjectService
    {
        private readonly List<Project> _projects;

        public ProjectServiceFake()
        {
            _projects = new List<Project>()
            {
                new Project()
                {
                    ProjectID = 1,
                    Title = "Test1",
                    Columns = new List<Column>()
                    {
                        new Column()
                        {
                            ProjectID = 1,
                            ColumnID = 1,
                            ColumnName = "Example 1",
                            Tasks = new List<BoardAPI.Models.ProjectsModels.Task>()
                            {
                                new BoardAPI.Models.ProjectsModels.Task()
                                {
                                    ColumnID = 1,
                                    TaskID = 1,
                                    Name = "Example task 1",
                                },
                                new BoardAPI.Models.ProjectsModels.Task()
                                {
                                    ColumnID = 1,
                                    TaskID = 2,
                                    Name = "Example task 2",
                                }
                            }
                        },
                        new Column()
                        {
                            ProjectID = 1,
                            ColumnID = 2,
                            ColumnName = "Example 2",
                            Tasks = new List<BoardAPI.Models.ProjectsModels.Task>()
                            {
                                new BoardAPI.Models.ProjectsModels.Task()
                                {
                                    ColumnID = 2,
                                    TaskID = 3,
                                    Name = "Example task 3",
                                },
                                new BoardAPI.Models.ProjectsModels.Task()
                                {
                                    ColumnID = 2,
                                    TaskID = 4,
                                    Name = "Example task 4",
                                }
                            }
                        }
                    },
                },
                new Project()
                {
                    ProjectID = 2,
                    Title = "Test2",
                    Columns = new List<Column>()
                    {
                        new Column()
                        {
                            ProjectID = 2,
                            ColumnID = 3,
                            ColumnName = "Example 3",
                            Tasks = new List<BoardAPI.Models.ProjectsModels.Task>()
                            {
                                new BoardAPI.Models.ProjectsModels.Task()
                                {
                                    ColumnID = 3,
                                    TaskID = 5,
                                    Name = "Example task 5",
                                },
                                new BoardAPI.Models.ProjectsModels.Task()
                                {
                                    ColumnID = 3,
                                    TaskID = 6,
                                    Name = "Example task 6",
                                }
                            }
                        },
                        new Column()
                        {
                            ProjectID = 2,
                            ColumnID = 4,
                            ColumnName = "Example 4",
                            Tasks = new List<BoardAPI.Models.ProjectsModels.Task>()
                            {
                                new BoardAPI.Models.ProjectsModels.Task()
                                {
                                    ColumnID = 4,
                                    TaskID = 7,
                                    Name = "Example task 7",
                                },
                                new BoardAPI.Models.ProjectsModels.Task()
                                {
                                    ColumnID = 4,
                                    TaskID = 8,
                                    Name = "Example task 8",
                                }
                            }
                        }
                    },
                },
                new Project()
                {
                    ProjectID = 3,
                    Title = "Test3",
                    Columns = new List<Column>()
                    {
                        new Column()
                        {
                            ProjectID = 3,
                            ColumnID = 5,
                            ColumnName = "Example 5",
                            Tasks = new List<BoardAPI.Models.ProjectsModels.Task>()
                            {
                                new BoardAPI.Models.ProjectsModels.Task()
                                {
                                    ColumnID = 5,
                                    TaskID = 9,
                                    Name = "Example task 9",
                                },
                                new BoardAPI.Models.ProjectsModels.Task()
                                {
                                    ColumnID = 5,
                                    TaskID = 10,
                                    Name = "Example task 10",
                                }
                            }
                        },
                        new Column()
                        {
                            ProjectID = 3,
                            ColumnID = 6,
                            ColumnName = "Example 6",
                            Tasks = new List<BoardAPI.Models.ProjectsModels.Task>()
                            {
                                new BoardAPI.Models.ProjectsModels.Task()
                                {
                                    ColumnID = 6,
                                    TaskID = 11,
                                    Name = "Example task 11",
                                },
                                new BoardAPI.Models.ProjectsModels.Task()
                                {
                                    ColumnID = 6,
                                    TaskID = 12,
                                    Name = "Example task 12",
                                }
                            }
                        }
                    },
                }
            };
        }

        public int CountOfProjectData()
        {
            return _projects.Count;
        }

        public async Task<ProjectResponse> DeleteAsync(int ID)
        {
            var existingProjectData = _projects.First(p => p.ProjectID == ID);
            _projects.Remove(existingProjectData);

            return await System.Threading.Tasks.Task.Run(() => new ProjectResponse(existingProjectData));
        }

        public Task<ColumnResponse> DeleteColumnAsync(int id, int columnID)
        {
            var existingProjectData = _projects.First(p => p.ProjectID == id);
            var columns = existingProjectData.Columns.ToList();
            var existingColumn = existingProjectData.Columns.First(c => c.ColumnID == columnID);

            columns.Remove(existingColumn);

            existingProjectData.Columns = columns;

            return System.Threading.Tasks.Task.Run(() => new ColumnResponse(existingColumn));
        }

        public Task<TaskResponse> DeleteTaskAsync(int id, int columnID, int taskID)
        {
            var existingProjectData = _projects.First(p => p.ProjectID == id);
            var existingColumn = existingProjectData.Columns.First(c => c.ColumnID == columnID);
            var tasks = existingColumn.Tasks.ToList();
            var existingTask = existingColumn.Tasks.First(t => t.TaskID == taskID);

            tasks.Remove(existingTask);

            existingColumn.Tasks = tasks;

            return System.Threading.Tasks.Task.Run(() => new TaskResponse(existingTask));
        }

        public Task<Project> FindByIDAsync(int ID)
        {
            return System.Threading.Tasks.Task.Run(() => _projects.First(p => p.ProjectID == ID));
        }

        public bool IsDbEmpty()
        {
            return !_projects.Any();
        }

        public Task<IEnumerable<Project>> ListAsync()
        {
            return System.Threading.Tasks.Task.Run(() => _projects.AsEnumerable());
        }

        public Task<ProjectResponse> SaveAsync(Project project)
        {
            _projects.Add(project);
            return System.Threading.Tasks.Task.Run(() => new ProjectResponse(project));
        }

        public Task<ColumnResponse> SaveAsyncColumn(Column column, int ProjectID)
        {
            var existingColumnsInProject = _projects.First(p => p.ProjectID == ProjectID).Columns.ToList();
            existingColumnsInProject.Add(column);
            
            return System.Threading.Tasks.Task.Run(() => new ColumnResponse(column));
        }

        public Task<TaskResponse> SaveAsyncTask(BoardAPI.Models.ProjectsModels.Task task, int ColumnID, int ProjectID)
        {
            var existingProject = _projects.First(p => p.ProjectID == ProjectID);
            var existingColumn = existingProject.Columns.First(c => c.ColumnID == ColumnID);
            var existingTasks = existingColumn.Tasks.ToList();

            existingTasks.Add(task);

            return System.Threading.Tasks.Task.Run(() => new TaskResponse(task));
        }

        public bool SpecificProjectDataExists(int ID)
        {
            return _projects.Select(p => p.ProjectID == ID).ToList().ElementAt(0);
        }

        public ProjectResponse Update(Project project)
        {
            var searchedProject = _projects.First(p => p.ProjectID == project.ProjectID);

            if (searchedProject == null)
                throw new AppException("Project not found");

            if (searchedProject.Title != project.Title)
            {
                // project title has changed so check if the new title is already taken
                if (_projects.Any(x => x.Title == project.Title))
                    throw new AppException("Title " + project.Title + " is already taken");
            }

            // update project properties
            searchedProject.Title = project.Title;

            return new ProjectResponse("Project was updated");
        }

        public ColumnResponse UpdateColumn(Column editColumn, int projectID, int columnID)
        {
            var project = FindByIDAsync(projectID).Result;
            var columnWithID = project.Columns.Where(x => x.ColumnID == columnID).ToList().ElementAt(0);

            if (project == null)
                throw new AppException("Project not found");

            // update project properties
            columnWithID.ColumnName = editColumn.ColumnName;

            return new ColumnResponse("Column was updated");
        }

        public TaskResponse UpdateTask(BoardAPI.Models.ProjectsModels.Task editTask, int id, int columnID, int taskID)
        {
            var project = _projects.First(p => p.ProjectID == id);
            var columnWithID = project.Columns.Where(x => x.ColumnID == columnID).ToList().ElementAt(0);
            var taskWithID = columnWithID.Tasks.Where(x => x.TaskID == taskID).ToList().ElementAt(0);

            if (project == null)
                throw new AppException("Project not found");

            // update project properties
            taskWithID.Name = editTask.Name;

            return new TaskResponse("Task was updated");
        }
    }
}
