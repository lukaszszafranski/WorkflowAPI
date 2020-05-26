using AutoMapper;
using BoardAPI.Controllers;
using BoardAPI.Services;
using WorkflowAPI.Tests.Fakers;

namespace WorkflowAPI.Tests.Tests
{
    public class OrganizationsControllerTests
    {
        OrganizationsController _controller;
        IOrganizationService _service;
        IMapper _mapper;

        public OrganizationsControllerTests()
        {
            _service = new OrganizationServiceFake();
            _controller = new OrganizationsController(_service, _mapper);
        }
    }
}
