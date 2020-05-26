/* 
 * Copyright (C) Work-FLow, All Rights Reserved
 * Unauthorized copying of this file, via any medium is strictly prohibited
 * Proprietary and confidential
 * Written by Łukasz Szafrański <lukasz.szafranski16@wp.pl>, Krzysztof Łepkowski, Szymon Lewandowski, May 2020
 */

using BoardAPI.Models.OrganizationsModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BoardAPI.Repositories
{
    public interface IOrganizationRepository
    {
        Task<IEnumerable<Organization>> ListAsync();
        Task AddAsync(Organization organization);
        Task<Organization> FindByIDAsync(int ID);
        int CountOfOrganizationData();
        void Remove(Organization organization);
        bool IsDbEmpty();
        bool SpecificOrganizationDataExists(int ID);
    }
}
