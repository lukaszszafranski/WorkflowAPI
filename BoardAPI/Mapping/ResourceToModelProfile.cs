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
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            //Project mapping
            CreateMap<SaveProjectResource, ProjectResource>();
            CreateMap<ProjectResource, Project>().ForMember(x => x.ProjectID, opt => opt.Ignore());
            CreateMap<SaveProjectResource, Project>().ForMember(x => x.ProjectID, opt => opt.Ignore());

            CreateMap<SaveWorkItemResource, WorkItemResource>();
            CreateMap<WorkItemResource, WorkItem>().ForMember(x => x.WorkItemID, opt => opt.Ignore());
            CreateMap<SaveWorkItemResource, WorkItem>().ForMember(x => x.WorkItemID, opt => opt.Ignore());

            CreateMap<SaveTagResource, TagResource>();
            CreateMap<TagResource, Tag>().ForMember(x => x.TagID, opt => opt.Ignore());
            CreateMap<SaveTagResource, Tag>().ForMember(x => x.TagID, opt => opt.Ignore());

            CreateMap<SaveColumnResource, ColumnResource>();
            CreateMap<ColumnResource, Column>().ForMember(x => x.ColumnID, opt => opt.Ignore());
            CreateMap<SaveColumnResource, Column>().ForMember(x => x.ColumnID, opt => opt.Ignore());

            //Organization mapping
            CreateMap<SaveOrganizationResource, OrganizationResource>();
            CreateMap<OrganizationResource, Organization>().ForMember(x => x.OrganizationID, opt => opt.Ignore());
            CreateMap<SaveOrganizationResource, Organization>().ForMember(x => x.OrganizationID, opt => opt.Ignore());

            //User mapping
            CreateMap<UserResource, User>();
            CreateMap<Task<IList<UserResource>>, Task<IList<User>>>();
            CreateMap<User, RegisterModel>();
            CreateMap<User, UpdateModel>();
        }
    }
}
