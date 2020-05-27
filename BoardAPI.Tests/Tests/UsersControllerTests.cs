/* 
 * Copyright (C) Work-FLow, All Rights Reserved
 * Unauthorized copying of this file, via any medium is strictly prohibited
 * Proprietary and confidential
 * Written by Łukasz Szafrański <lukasz.szafranski16@wp.pl>, Krzysztof Łepkowski, Szymon Lewandowski, May 2020
 */

using AutoMapper;
using BoardAPI.Controllers;
using BoardAPI.Helpers;
using BoardAPI.Models.UserModels;
using BoardAPI.Services;
using BoardAPI.Services.Communication;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using WorkflowAPI.Tests.Fakers;

namespace WorkflowAPI.Tests.Tests
{
    [TestFixture]
    public class UsersControllerTests
    {
        UsersController _controller;
        IUserService _service;
        IMapper _mapper;


        [SetUp]
        public void setUpTests()
        {
            _service = new UserServiceFake();
            _controller = new UsersController(_service, _mapper);
        }

        [Test]
        public void getById_PassedCorrectId_ReturnCorrectType()
        {
            //act
            var result = _service.GetById(1);

            //assert
            Assert.IsInstanceOf<User>(result);
        }

        [Test]
        public void getById_PassedIncorrectId_ReturnArgumentOutOfRangeException()
        {
            //assert
            Assert.Throws<ArgumentOutOfRangeException>(() => _service.GetById(236));
        }

        [Test]
        public void getAll_ReturnCorrectType()
        {
            //act
            var result = _service.GetAll().Result;

            //assert
            Assert.IsInstanceOf<IEnumerable<User>>(result);
        }

        [Test]
        public void deleteUser_PassedCorrectId_ReturnUserResponse()
        {
            //act
            var result = _service.Delete(1);

            //assert
            Assert.IsInstanceOf<UserResponse>(result);
        }

        [Test]
        public void deleteUser_PassedCorrectId_ReturnSuccess()
        {
            //act
            var result = _service.Delete(1);

            //assert
            Assert.IsTrue(result.Success);
        }

        [Test]
        public void deleteUser_PassedIncorrectId_ReturnInvalidOperationException()
        {
            //assert
            Assert.Throws<InvalidOperationException>(() => _service.Delete(236));
        }


        [Test]
        public void authenticate_PassedCorrectLoginAndPassword_ReturnInstanceOfUser()
        {
            //act
            var result = _service.Authenticate("TestUser", "TestSelenium1");

            //assert
            Assert.IsInstanceOf<User>(result);
        }

        [Test]
        public void authenticate_PassedCorrectLoginAndIncorrectPassword_ReturnNull()
        {
            //act
            var result = _service.Authenticate("TestUser", "Incorrect");

            //assert
            Assert.IsNull(result);
        }

        [Test]
        public void authenticate_PassedIncorrectLogin_ReturnNull()
        {
            //act
            var result = _service.Authenticate("Incorrect", "TestSelenium1");

            //assert
            Assert.IsNull(result);
        }

        [Test]
        public void createUser_PassedNewUserAndPassword_ReturnNewUser()
        {
            //arrange
            User createdUser = new User()
            {
                FirstName = "Alex",
                LastName = "Nowak",
                Username = "TestUser3"
            };
            //act
            var result = _service.Create(createdUser, "TestSelenium1");

            //assert
            Assert.IsInstanceOf<User>(result);
        }

        [Test]
        public void createUser_PassedNewUserAndEmptyPassword_ReturnAppException()
        {
            //arrange
            User createdUser = new User()
            {
                FirstName = "Alex",
                LastName = "Nowak",
                Username = "TestUser3"
            };
            //act + assert
            var ex = Assert.Throws<AppException>(() => _service.Create(createdUser, ""));

            Assert.That(ex.Message, Is.EqualTo("Password is required"));
        }

        [Test]
        public void createUser_PassedUsernameThatIsAlreadyTaken_ReturnAppException()
        {
            //arrange
            User createdUser = new User()
            {
                FirstName = "Alex",
                LastName = "Nowak",
                Username = "TestUser"
            };
            //act + assert
            var ex = Assert.Throws<AppException>(() => _service.Create(createdUser, "TestSelenium1"));

            Assert.That(ex.Message, Is.EqualTo("Username \"" + createdUser.Username + "\" is already taken"));
        }


        [Test]
        public void updateUser_PassedCorrectUserDetails_ReturnUpdatedUser()
        {
            //arrange
            User updatedUser = new User()
            {
                Id = 1,
                FirstName = "Alex",
                LastName = "Nowak",
                Username = "TestUser3"
            };

            //act
            var result = _service.Update(updatedUser, "TestSelenium2");

            //assert
            Assert.IsInstanceOf<UserResponse>(result);
        }

        [Test]
        public void updateUser_PassedCorrectUserDetailsWithoutPassword_ReturnUpdatedUser()
        {
            //arrange
            User updatedUser = new User()
            {
                Id = 1,
                FirstName = "Alex",
                LastName = "Nowak",
                Username = "TestUser3"
            };

            //act
            var result = _service.Update(updatedUser);

            //assert
            Assert.IsInstanceOf<UserResponse>(result);
        }

        [Test]
        public void updateUser_UserNotFound_ReturnAppException()
        {
            //arrange
            User updatedUser = new User()
            {
                Id = 3,
                FirstName = "Alex",
                LastName = "Nowak",
                Username = "TestUser3"
            };

            //act + assert
            var ex = Assert.Throws<AppException>(() => _service.Update(updatedUser));

            Assert.That(ex.Message, Is.EqualTo("User not found"));
        }

        [Test]
        public void updateUser_PassedUsernameThatIsAlreadyTaken_ReturnAppException()
        {
            //arrange
            User updatedUser = new User()
            {
                Id = 2,
                FirstName = "Alex",
                LastName = "Nowak",
                Username = "TestUser"
            };

            //act + assert
            var ex = Assert.Throws<AppException>(() => _service.Update(updatedUser));

            Assert.That(ex.Message, Is.EqualTo("Username " + updatedUser.Username + " is already taken"));
        }
    }   
}
