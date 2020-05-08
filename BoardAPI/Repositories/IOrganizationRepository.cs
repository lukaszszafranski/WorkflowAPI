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
