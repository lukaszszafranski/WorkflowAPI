using AutoMapper;
using BoardAPI.Controllers;
using BoardAPI.Models.ProjectsModels;
using BoardAPI.Services;
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
        public void Get_WhenCalledWithDifferentMethod_IsNotAnInstanceOf()
        {
            // Act
            var result = _service.CountOfProjectData();

            // Assert
            Assert.IsNotInstanceOf<IEnumerable<Project>>(result);
        }

        [Test]
        public void GetCount_CalledService_ReturnCorrectAmount()
        {
            // Act
            var result = _service.CountOfProjectData();

            // Assert
            Assert.That(result, Is.EqualTo(3));
        }


    }
}
