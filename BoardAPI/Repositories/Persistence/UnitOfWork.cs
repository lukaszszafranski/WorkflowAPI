using BoardAPI.Data;
using BoardAPI.Repositories.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoardAPI.Repositories.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BoardAPIContext _context;

        public UnitOfWork(BoardAPIContext context)
        {
            _context = context;
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
