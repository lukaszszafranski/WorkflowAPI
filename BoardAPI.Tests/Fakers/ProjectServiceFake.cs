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
            throw new NotImplementedException();
        }

        public Task<TaskResponse> DeleteTaskAsync(int id, int columnID, int taskID)
        {
            throw new NotImplementedException();
        }

        public Task<Project> FindByIDAsync(int ID)
        {
            throw new NotImplementedException();
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
            return System.Threading.Tasks.Task.Run(() => new ProjectResponse(project));
        }

        public Task<ColumnResponse> SaveAsyncColumn(Column column, int ProjectID)
        {
            throw new NotImplementedException();
        }

        public Task<TaskResponse> SaveAsyncTask(BoardAPI.Models.ProjectsModels.Task task, int ColumnID, int ProjectID)
        {
            throw new NotImplementedException();
        }

        public bool SpecificProjectDataExists(int ID)
        {
            return _projects.Select(p => p.ProjectID == ID).ToList().ElementAt(0);
        }

        public ProjectResponse Update(Project project)
        {
            throw new NotImplementedException();
        }

        public ColumnResponse UpdateColumn(Column editProject, int projectID, int columnID)
        {
            throw new NotImplementedException();
        }

        public TaskResponse UpdateTask(BoardAPI.Models.ProjectsModels.Task editProject, int id, int columnID, int taskID)
        {
            throw new NotImplementedException();
        }
    }
}
