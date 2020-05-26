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
