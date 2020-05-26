using AutoMapper;
using BoardAPI.Controllers;
using BoardAPI.Services;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using WorkflowAPI.Tests.Fakers;

namespace WorkflowAPI.Tests.Tests
{
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
    }
}
