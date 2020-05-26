using AutoMapper;
using BoardAPI.Controllers;
using BoardAPI.Helpers;
using BoardAPI.Services;
using Microsoft.Extensions.Options;
using WorkflowAPI.Tests.Fakers;

namespace WorkflowAPI.Tests.Tests
{
    public class UsersControllerTests
    {
        UsersController _controller;
        IUserService _service;
        IMapper _mapper;

        public UsersControllerTests()
        {
            _service = new UserServiceFake();
            _controller = new UsersController(_service, _mapper);
        }
    }
}
