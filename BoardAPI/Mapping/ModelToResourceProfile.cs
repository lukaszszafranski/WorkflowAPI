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
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            //Project Mapping
            CreateMap<Project, ProjectResource>();
            CreateMap<ProjectResource, SaveProjectResource>();
            CreateMap<Column, ColumnResource>();
            CreateMap<ColumnResource, SaveColumnResource>();
            CreateMap<Models.ProjectsModels.Task, TaskResource>();
            CreateMap<TaskResource, SaveTaskResource>();
            //Organization Mapping
            CreateMap<Organization, OrganizationResource>();
            CreateMap<OrganizationResource, SaveOrganizationResource>();

            //User Mapping
            CreateMap<User, UserResource>();
            CreateMap<Task<IList<User>>, Task<IList<UserResource>>>();
            CreateMap<RegisterModel, User>();
            CreateMap<UpdateModel, User>();

            //Role mapping
            CreateMap<Role, RoleResource>();

            //Timesheet mapping
            CreateMap<Timesheet, TimesheetResource>();
            CreateMap<Timesheet, ManagerTimesheetResource>();
            CreateMap<TimesheetDetails, TimesheetDetailsResource>();
        }
    }
}
