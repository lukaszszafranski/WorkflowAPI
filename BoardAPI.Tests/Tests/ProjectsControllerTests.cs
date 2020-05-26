using AutoMapper;
using BoardAPI.Controllers;
using BoardAPI.Helpers;
using BoardAPI.Models.ProjectsModels;
using BoardAPI.Services;
using BoardAPI.Services.Communication;
using Microsoft.Extensions.Logging;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WorkflowAPI.Tests.Fakers;

namespace WorkflowAPI.Tests.Tests
{
    [TestFixture]
    public class ProjectsControllerTests
    {
        ProjectsController _controller;
        IProjectService _service;
        IMapper _mapper;

        public ProjectsControllerTests()
        {
            _service = new ProjectServiceFake();
            _controller = new ProjectsController(_service, _mapper);
        }

        [Test]
        public void Get_WhenCalled_ReturnsCorrectItems()
        {
            // Act
            var result = _service.ListAsync().Result;

            // Assert
            Assert.IsInstanceOf<IEnumerable<Project>>(result);
        }

        [Test]
        public void Get_WhenCalled_ReturnsCorrectAmountOfItems()
        {
            // Act
            var result = _service.ListAsync().Result;

            // Assert
            Assert.That(result.Count(), Is.EqualTo(3));
        }

        [Test]
        public void GetCount_CalledService_ReturnCorrectAmount()
        {
            // Act
            var result = _service.CountOfProjectData();

            // Assert
            Assert.That(result, Is.EqualTo(3));
        }

        [Test]
        public void GetCount_CalledService_ReturnCorrectType()
        {
            // Act
            var result = _service.CountOfProjectData();

            // Assert
            Assert.IsInstanceOf<int>(result);
        }

        [Test]
        public void FindByIDAsync_CorrectIDPassed_ReturnProject()
        {
            // Act
            var result = _service.FindByIDAsync(1).Result;

            // Assert
            Assert.IsInstanceOf<Project>(result);
        }

        [Test]
        public void FindByIDAsync_WrongIDPassed_ReturnsInvalidOperationException()
        {
            // Assert
            Assert.ThrowsAsync<InvalidOperationException>(() => _service.FindByIDAsync(22));
        }

        [Test]
        public void IsDbEmpty_ProjectsExist_ReturnsFalse()
        {
            // Act
            var result = _service.IsDbEmpty();

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void IsDbEmpty_ProjectsExist_ReturnCorrectType()
        {
            // Act
            var result = _service.IsDbEmpty();

            // Assert
            Assert.IsInstanceOf<bool>(result);
        }

        [Test]
        public void SpecificProjectDataExists_ProjectExist_ReturnTrue()
        {
            // Act
            var result = _service.SpecificProjectDataExists(1);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void SpecificProjectDataExists_ProjectDoesNotExist_ReturnFalse()
        {
            // Act
            var result = _service.SpecificProjectDataExists(132);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void UpdateProject_PassedExistingProject_ReturnCorrectMessage()
        {
            // Arrange
            var updatedProject = new Project()
            {
                ProjectID = 1,
                Title = "Changed title",
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
            };

            // Act
            var result = _service.Update(updatedProject);

            // Assert
            Assert.IsInstanceOf<ProjectResponse>(result);
        }

        [Test]
        public void UpdateProject_PassedExistingProjectWithTheSameTitle_ReturnProjectResponse()
        {
            // Arrange
            var updatedProject = new Project()
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
            };

            // Act
            var result = _service.Update(updatedProject);

            // Assert
            Assert.IsInstanceOf<ProjectResponse>(result);
        }

        [Test]
        public void UpdateProject_PassedExistingProjectWithTheSameTitleAsOtherProject_ReturnAppException()
        {
            // Arrange
            var updatedProject = new Project()
            {
                ProjectID = 1,
                Title = "Test2",
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
            };

            // Assert
            var ex = Assert.Throws<AppException>(() => _service.Update(updatedProject));
            Assert.That(ex.Message, Is.EqualTo("Title " + updatedProject.Title + " is already taken"));
        }

        [Test]
        public void UpdateProject_PassedNotExistingProject_ReturnInvalidOperationException()
        {
            // Arrange
            var updatedProject = new Project()
            {
                ProjectID = 123,
                Title = "Changed title",
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
            };

            // Assert
            Assert.Throws<InvalidOperationException>(() => _service.Update(updatedProject));
        }

        [Test]
        public void UpdateColumn_PassedExistingColumn_ReturnCorrectMessage()
        {
            // Arrange
            var updatedColumn = new Column()
            {
                ColumnID = 1,
                ColumnName = "Example 3"
            };

            // Act
            var result = _service.UpdateColumn(updatedColumn, 1, 1);

            // Assert
            Assert.IsInstanceOf<ColumnResponse>(result);
        }

        [Test]
        public void UpdateColumn_PassedExistingColumnWithTheSameTitle_ReturnCorrectMessage()
        {
            // Arrange
            var updatedColumn = new Column()
            {
                ColumnID = 1,
                ColumnName = "Example 1"
            };

            // Act
            var result = _service.UpdateColumn(updatedColumn, 1, 1);

            // Assert
            Assert.IsInstanceOf<ColumnResponse>(result);
        }

        [Test]
        public void UpdateColumn_PassedExistingColumnWithTheSameTitleAsOtherColumnInCurrentProject_ReturnCorrectMessage()
        {
            // Arrange
            var updatedColumn = new Column()
            {
                ColumnID = 1,
                ColumnName = "Example 2"
            };

            // Act
            var result = _service.UpdateColumn(updatedColumn, 1, 1);

            // Assert
            Assert.IsInstanceOf<ColumnResponse>(result);
        }

        [Test]
        public void UpdateColumn_PassedExistingColumnWithWrongID_ReturnArgumentOutOfRangeException()
        {
            // Arrange
            var updatedColumn = new Column()
            {
                ColumnID = 1,
                ColumnName = "Example 2"
            };

            // Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => _service.UpdateColumn(updatedColumn, 1, 1234));
        }

        [Test]
        public void UpdateTask_PassedExistingTask_ReturnCorrectMessage()
        {
            // Arrange
            var updatedTask = new Task()
            {
                TaskID = 1,
                Name = "Example task 12"
            };

            var result = _service.UpdateTask(updatedTask, 1, 1, 1);

            // Assert
            Assert.IsInstanceOf<TaskResponse>(result);
        }

        [Test]
        public void UpdateTask_PassedExistingTaskWithTheSameTitle_ReturnCorrectMessage()
        {
            // Arrange
            var updatedTask = new Task()
            {
                TaskID = 1,
                Name = "Example task 1"
            };

            var result = _service.UpdateTask(updatedTask, 1, 1, 1);

            // Assert
            Assert.IsInstanceOf<TaskResponse>(result);
        }

        [Test]
        public void UpdateTask_PassedNotExistingTask_ReturnArgumentOutOfRangeException()
        {
            // Arrange
            var updatedTask = new Task()
            {
                TaskID = 1,
                Name = "Example task 1"
            };

            // Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => _service.UpdateTask(updatedTask, 1, 1, 1234));
        }

        [Test]
        public void UpdateTask_PassedNotExistingColumnButCorrectTask_ReturnArgumentOutOfRangeException()
        {
            // Arrange
            var updatedTask = new Task()
            {
                TaskID = 1,
                Name = "Example task 1"
            };

            // Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => _service.UpdateTask(updatedTask, 1, 1234, 1));
        }

        [Test]
        public void UpdateTask_PassedExistingColumnAndTaskButNotExistingProject_ReturnInvalidOperationException()
        {
            // Arrange
            var updatedTask = new Task()
            {
                TaskID = 1,
                Name = "Example task 1"
            };

            // Assert
            Assert.Throws<InvalidOperationException>(() => _service.UpdateTask(updatedTask, 1234, 1, 1));
        }

        [Test]
        public void DeleteAsync_PassedExistingProject_ReturnCorrectType()
        {
            //// Act
            //var result = _service.DeleteAsync(1);

            //// Assert
            //Assert.IsInstanceOf<ProjectResponse>(result);
        }

        [Test]
        public void DeleteAsync_PassedNonExistingProject_ReturnCorrectType()
        { 
            // Assert
            Assert.ThrowsAsync<InvalidOperationException>(() => _service.DeleteAsync(1234));
        }
    }
}
