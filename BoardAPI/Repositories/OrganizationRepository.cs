﻿using BoardAPI.Data;
using BoardAPI.Models.OrganizationsModels;
using BoardAPI.Repositories.Persistence;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoardAPI.Repositories
{
    public class OrganizationRepository : BaseRepository, IOrganizationRepository
    {
        private new BoardAPIContext _context;

        public OrganizationRepository(BoardAPIContext context) : base(context)
        {
            _context = context;
        }
        public async Task AddAsync(Organization organization)
        {
            await _context.Organizations.AddAsync(organization);
        }

        public int CountOfOrganizationData()
        {
            return _context.Organizations.ToList().Count();
        }

        public async Task<Organization> FindByIDAsync(int ID)
        {
            return await Task.Run(() => _context.Organizations.Where(o => o.OrganizationID == ID).ElementAt(0));
        }

        public bool IsDbEmpty()
        {
            return !_context.Organizations.Any();
        }

        public async Task<IEnumerable<Organization>> ListAsync()
        {
            return await Task.Run(() => _context.Organizations.ToList());
        }

        public void Remove(Organization organization)
        {
            _context.Organizations.Remove(organization);
        }

        public bool SpecificOrganizationDataExists(int ID)
        {
            return _context.Organizations.Any(o => o.OrganizationID == ID);
        }
    }
}
