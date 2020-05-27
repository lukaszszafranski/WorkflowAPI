using AutoMapper;
using BoardAPI.Controllers;
using BoardAPI.Models.OrganizationsModels;
using BoardAPI.Services;
using BoardAPI.Services.Communication;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using System;
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
        public void Get_WhenCalled_ReturnsCorrectAmountOfItems()
        {
            // Act
            var result = _service.ListAsync().Result;

            // Assert
            Assert.That(result.Count(), Is.EqualTo(1));
        }

        [Test]
        public void Get_WhenCalled_ReturnsCorrectItems()
        {
            // Act
            var result = _service.ListAsync().Result;

            // Assert
            Assert.IsInstanceOf<IEnumerable<Organization>>(result);
        }

        [Test]
        public void GetCount_CalledService_ReturnCorrectType()
        {
            // Act
            var result = _service.CountOfOrganizationData();

            // Assert
            Assert.IsInstanceOf<int>(result);
        }

        [Test]
        public void GetCount_CalledService_ReturnCorrectAmount()
        {
            // Act
            var result = _service.CountOfOrganizationData();

            // Assert
            Assert.That(result, Is.EqualTo(1));
        }

        [Test]
        public void OrganizationDataExists_OrganizationExist_ReturnTrue()
        {
            // Act
            var result = _service.SpecificOrganizationDataExists(1);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void OrganizationsDataExists_ProjectDoesNotExist_ReturnFalse()
        {
            // Act
            var result = _service.SpecificOrganizationDataExists(1231);

            // Assert
            Assert.IsFalse(result);
        }


        [Test]
        public void OrganizationsDb_RemoveItem_Success()
        {
            // Act
            var result = _service.DeleteAsync(1).Result;
            // Assert
            Assert.IsInstanceOf<OrganizationResponse>(result);
        }

        [Test]
        public void DeleteAsync_PassedNonExistingOrganization_ReturnCorrectType()
        {
            // Assert
            Assert.ThrowsAsync<InvalidOperationException>(() => _service.DeleteAsync(1234));
        }

        [Test]
        public void IsDbEmpty_OrganizationExist_ReturnCorrectType()
        {
            // Act
            var result = _service.IsDbEmpty();

            // Assert
            Assert.IsInstanceOf<bool>(result);
        }

        [Test]
        public void IsDbEmpty_OrganizationExist_ReturnFalse()
        {
            // Act
            var result = _service.IsDbEmpty();

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void FindByIDAsync_CorrectIDPassed_ReturnOrganization()
        {
            // Act
            var result = _service.FindByIDAsync(1).Result;

            // Assert
            Assert.IsInstanceOf<Organization>(result);
        }

        [Test]
        public void FindByIDAsync_WrongIDPassed_ReturnsInvalidOperationException()
        {
            // Assert
            Assert.ThrowsAsync<InvalidOperationException>(() => _service.FindByIDAsync(22));
        }

        [Test]
        public void SaveAsync_PassedNonExistingOrganization_ReturnCorrectType()
        {
            // Arrange
            var organization = new Organization()
            {
                OrganizationID = 2,
                OrganizationName = "Organization2"
            };

            // Act
            var result = _service.SaveAsync(organization).Result;

            // Assert
            Assert.That(_service.ListAsync().Result.Count(), Is.EqualTo(2));
        }

        [Test]
        public void SaveAsync_PassedExistingOrganizationWithTheSameTitle_ReturnCorrectMessage()
        {
            // Arrange
            var organization = new Organization()
            {
                OrganizationID = 1,
                OrganizationName = "Organization1"
            };

            // Act
            var result = _service.SaveAsync(organization).Result;

            // Assert
            Assert.IsInstanceOf<OrganizationResponse>(result);
        }
    }
}
