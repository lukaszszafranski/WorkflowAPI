using System.Collections.Generic;
using System.Threading.Tasks;
using BoardAPI.Models.UserModels;
using BoardAPI.Services;
using BoardAPI.Services.Communication;

namespace WorkflowAPI.Tests.Fakers
{
    public class UserServiceFake : IUserService
    {
        public UserServiceFake()
        {
            new User()
            {

            };
        }

        public User Authenticate(string username, string password)
        {
            throw new System.NotImplementedException();
        }

        public User Create(User user, string password)
        {
            throw new System.NotImplementedException();
        }

        public UserResponse Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<User>> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public User GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public UserResponse Update(User user, string password = null)
        {
            throw new System.NotImplementedException();
        }
    }
}
