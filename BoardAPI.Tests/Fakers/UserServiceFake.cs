/* 
 * Copyright (C) Work-FLow, All Rights Reserved
 * Unauthorized copying of this file, via any medium is strictly prohibited
 * Proprietary and confidential
 * Written by Łukasz Szafrański <lukasz.szafranski16@wp.pl>, Krzysztof Łepkowski, Szymon Lewandowski, May 2020
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BoardAPI.Helpers;
using BoardAPI.Models.UserModels;
using BoardAPI.Services;
using BoardAPI.Services.Communication;

namespace WorkflowAPI.Tests.Fakers
{
    public class UserServiceFake : IUserService
    {
        private readonly List<User> _users;

        byte[] arrayHash, arraySalt;

        public UserServiceFake()
        {
            CreatePasswordHash("TestSelenium1", out arrayHash, out arraySalt);

            _users = new List<User>()
            {
                new User()
                {
                    Id = 1,
                    FirstName = "John",
                    LastName = "Kowalski",
                    Username = "TestUser",
                    PasswordHash = arrayHash,
                    PasswordSalt = arraySalt
                },

                new User()
                {
                    Id = 2,
                    FirstName = "John",
                    LastName = "Nowak",
                    Username = "TestUser2",
                    PasswordHash = arrayHash,
                    PasswordSalt = arraySalt
                },
            };
        }

        public User Authenticate(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                return null;

            var user = _users.SingleOrDefault(x => x.Username == username);

            // check if username exists
            if (user == null)
                return null;

            // check if password is correct
            if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                return null;

            // authentication successful
            return user;
        }

        public User Create(User user, string password)
        {
            // validation
            if (string.IsNullOrWhiteSpace(password))
                throw new AppException("Password is required");

            if (_users.Any(x => x.Username == user.Username))
                throw new AppException("Username \"" + user.Username + "\" is already taken");

            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(password, out passwordHash, out passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            _users.Add(user);

            return user;
        }

        public UserResponse Delete(int id)
        {
            var userToDelete = _users.First(x => x.Id == id);
            _users.Remove(userToDelete);

            return new UserResponse(userToDelete);
        }

        public Task<IEnumerable<User>> GetAll()
        {
            return System.Threading.Tasks.Task.Run(() => _users.AsEnumerable());
        }

        public User GetById(int id)
        {
            return _users.Where(x => x.Id == id).ToList().ElementAt(0);
        }

        public UserResponse Update(User user, string password = null)
        {
            if (!_users.Exists(x => x.Id == user.Id))
                throw new AppException("User not found");

            var tempUser = _users.First(x => x.Id == user.Id);

            if (user.Username != tempUser.Username)
            {
                // username has changed so check if the new username is already taken
                if (_users.Any(x => x.Username == user.Username))
                    throw new AppException("Username " + user.Username + " is already taken");
            }

            // update user properties
            tempUser.FirstName = user.FirstName;
            tempUser.LastName = user.LastName;
            tempUser.Username = user.Username;

            // update password if it was entered
            if (!string.IsNullOrWhiteSpace(password))
            {
                byte[] passwordHash, passwordSalt;
                CreatePasswordHash(password, out passwordHash, out passwordSalt);

                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;
            }

            return new UserResponse("User was updated");
        }

        // HELPER METHODS

        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");

            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private static bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");
            if (storedHash.Length != 64) throw new ArgumentException("Invalid length of password hash (64 bytes expected).", "passwordHash");
            if (storedSalt.Length != 128) throw new ArgumentException("Invalid length of password salt (128 bytes expected).", "passwordHash");

            using (var hmac = new System.Security.Cryptography.HMACSHA512(storedSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != storedHash[i]) return false;
                }
            }

            return true;
        }


        //////
    }
}
