using AutoMapper;
using BoardAPI.Controllers;
using BoardAPI.Models.OrganizationsModels;
using BoardAPI.Services;
using BoardAPI.Services.Communication;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using WorkflowAPI.Tests.Fakers;

namespace WorkflowAPI.Tests.Tests
{
    [TestFixture]
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

        [Test]
        public void OrganizationsCount_ListAsync_ReturnsCorrectAmount()
        {
            // Act
            var result = _service.ListAsync().Result;
            // Assert
            Assert.IsInstanceOf<IEnumerable<Organization>>(result);
        }

        [Test]
        public void OrganizationsDb_IsEmpty_ReturnFalse()
        {
            // Act
            var result = _service.IsDbEmpty();
            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void OrganizationsDataExists_Search_DataFound()
        {
            // Act
            var result = _service.SpecificOrganizationDataExists(1);
            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void OrganizationsCount_GetCount()
        {
            // Act
            var result = _service.CountOfStockData();
            // Assert
            Assert.That(result, Is.EqualTo(1));
        }

        [Test]
        public void OrganizationsDb_RemoveItem_Success()
        {
            // Act
            var result = _service.DeleteAsync(1).Result;
            // Assert
            Assert.IsInstanceOf<OrganizationResponse>(result);
        }

    }
}
