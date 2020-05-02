using AutoMapper;
using BoardAPI.Models.UserModels;
using BoardAPI.Resources;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BoardAPI.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<User, UserResource>();
            CreateMap<Task<IList<User>>, Task<IList<UserResource>>>();
            CreateMap<RegisterModel, User>();
            CreateMap<UpdateModel, User>();
        }
    }
}
