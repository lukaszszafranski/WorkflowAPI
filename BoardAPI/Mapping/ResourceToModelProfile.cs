using AutoMapper;
using BoardAPI.Models.UserModels;
using BoardAPI.Resources;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BoardAPI.Mapping
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<UserResource, User>();
            CreateMap<Task<IList<UserResource>>, Task<IList<User>>>();
            CreateMap<User, RegisterModel>();
            CreateMap<User, UpdateModel>();
        }
    }
}
