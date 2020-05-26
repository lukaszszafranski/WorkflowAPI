/* 
 * Copyright (C) Work-FLow, All Rights Reserved
 * Unauthorized copying of this file, via any medium is strictly prohibited
 * Proprietary and confidential
 * Written by Łukasz Szafrański <lukasz.szafranski16@wp.pl>, Krzysztof Łepkowski, Szymon Lewandowski, May 2020
 */

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

            CreateMap<SaveColumnResource, ColumnResource>();
            CreateMap<ColumnResource, Column>();
            CreateMap<SaveColumnResource, Column>();

            CreateMap<SaveTaskResource, TaskResource>();
            CreateMap<SaveTaskResource, Models.ProjectsModels.Task>();
            CreateMap<TaskResource, Models.ProjectsModels.Task>();

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
