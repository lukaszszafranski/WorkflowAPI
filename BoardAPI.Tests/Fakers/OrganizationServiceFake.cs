/* 
 * Copyright (C) Work-FLow, All Rights Reserved
 * Unauthorized copying of this file, via any medium is strictly prohibited
 * Proprietary and confidential
 * Written by Łukasz Szafrański <lukasz.szafranski16@wp.pl>, Krzysztof Łepkowski, Szymon Lewandowski, May 2023
 */

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BoardAPI.Models.OrganizationsModels;
using BoardAPI.Services;
using BoardAPI.Services.Communication;

namespace WorkflowAPI.Tests.Fakers
{
    public class OrganizationServiceFake : IOrganizationService
    {
        private readonly List<Organization> _organizations;

        public OrganizationServiceFake()
        {
            _organizations = new List<Organization>()
            {
                new Organization()
                {
                    OrganizationID = 1,
                    OrganizationName = "Organization1"
                },
            };
        }

        public int CountOfOrganizationData()
        {
            return _organizations.Count();
        }

        public Task<OrganizationResponse> DeleteAsync(int ID)
        {
            var removeItem = _organizations.First(o => o.OrganizationID == ID);
            _organizations.Remove(removeItem);
            return Task.Run(() => new OrganizationResponse(removeItem));
        }

        public Task<Organization> FindByIDAsync(int ID)
        {
            return Task.Run(() => _organizations.First(o => o.OrganizationID == ID));
        }

        public bool IsDbEmpty()
        {
            return !_organizations.Any();
        }

        public Task<IEnumerable<Organization>> ListAsync()
        {
            return Task.Run(() => _organizations.AsEnumerable());
        }

        public Task<OrganizationResponse> SaveAsync(Organization organization)
        {
            _organizations.Add(organization);
            return Task.Run(() => new OrganizationResponse(organization));
        }

        public bool SpecificOrganizationDataExists(int ID)
        {
            return _organizations.Select(o => o.OrganizationID == ID).ToList().ElementAt(0);
        }
    }
}
