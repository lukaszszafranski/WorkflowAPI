using AutoMapper;
using BoardAPI.Models.OrganizationsModels;
using BoardAPI.Models.ProjectsModels;
using BoardAPI.Models.UserModels;
using BoardAPI.Resources;
using System.Collections.Generic;
using System.Threading.Tasks;
using static BoardAPI.Resources.ProjectResource;
using static BoardAPI.Resources.SaveProjectResource;

namespace BoardAPI.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            //Project Mapping
            CreateMap<Project, ProjectResource>();
            CreateMap<ProjectResource, SaveProjectResource>();
            CreateMap<Tag, TagResource>();
            CreateMap<Column, ColumnResource>();
            CreateMap<WorkItem, WorkItemResource>();
            CreateMap<TagResource, SaveTagResource>();
            CreateMap<ColumnResource, SaveColumnResource>();
            CreateMap<WorkItemResource, SaveWorkItemResource>();

            //Organization Mapping
            CreateMap<Organization, OrganizationResource>();
            CreateMap<OrganizationResource, SaveOrganizationResource>();

            //User Mapping
            CreateMap<User, UserResource>();
            CreateMap<Task<IList<User>>, Task<IList<UserResource>>>();
            CreateMap<RegisterModel, User>();
            CreateMap<UpdateModel, User>();
        }
    }
}
