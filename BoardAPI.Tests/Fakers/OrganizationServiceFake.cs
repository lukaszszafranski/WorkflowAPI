﻿using System.Collections.Generic;
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

        public int CountOfStockData()
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
            throw new System.NotImplementedException();
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
            throw new System.NotImplementedException();
        }

        public bool SpecificOrganizationDataExists(int ID)
        {
            return _organizations.Select(o => o.OrganizationID == ID).ToList().ElementAt(0);
        }
    }
}
