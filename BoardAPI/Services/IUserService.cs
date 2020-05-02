﻿using BoardAPI.Models.UserModels;
using BoardAPI.Services.Communication;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BoardAPI.Services
{
    public interface IUserService
    {
        User Authenticate(string username, string password);
        Task<IEnumerable<User>> GetAll();
        User GetById(int id);
        User Create(User user, string password);
        UserResponse Update(User user, string password = null);
        UserResponse Delete(int id);
    }
}
