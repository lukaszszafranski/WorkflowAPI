using System.Collections.Generic;
using System.Threading.Tasks;
using BoardAPI.Models.OrganizationsModels;
using BoardAPI.Services;
using BoardAPI.Services.Communication;

namespace WorkflowAPI.Tests.Fakers
{
    public class OrganizationServiceFake : IOrganizationService
    {
        public OrganizationServiceFake()
        {
            new Organization()
            {

            };
        }

        public int CountOfStockData()
        {
            throw new System.NotImplementedException();
        }

        public Task<OrganizationResponse> DeleteAsync(int ID)
        {
            throw new System.NotImplementedException();
        }

        public Task<Organization> FindByIDAsync(int ID)
        {
            throw new System.NotImplementedException();
        }

        public bool IsDbEmpty()
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<Organization>> ListAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<OrganizationResponse> SaveAsync(Organization organization)
        {
            throw new System.NotImplementedException();
        }

        public bool SpecificOrganizationDataExists(int ID)
        {
            throw new System.NotImplementedException();
        }
    }
}
