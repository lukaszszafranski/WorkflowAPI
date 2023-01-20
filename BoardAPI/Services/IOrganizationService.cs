/* 
 * Copyright (C) Work-FLow, All Rights Reserved
 * Unauthorized copying of this file, via any medium is strictly prohibited
 * Proprietary and confidential
 * Written by Łukasz Szafrański <lukasz.szafranski16@wp.pl>, Krzysztof Łepkowski, Szymon Lewandowski, May 2023
 */

using BoardAPI.Models.OrganizationsModels;
using BoardAPI.Services.Communication;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BoardAPI.Services
{
    public interface IOrganizationService
    {
        Task<IEnumerable<Organization>> ListAsync();
        Task<OrganizationResponse> SaveAsync(Organization organization);
        Task<Organization> FindByIDAsync(int ID);
        Task<OrganizationResponse> DeleteAsync(int ID);
        int CountOfOrganizationData();
        bool IsDbEmpty();
        bool SpecificOrganizationDataExists(int ID);
    }
}
