using BoardAPI.Data;
using BoardAPI.Repositories.Domain;
using System.Threading.Tasks;

namespace BoardAPI.Repositories.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly WorkflowAPIContext _context;

        public UnitOfWork(WorkflowAPIContext context)
        {
            _context = context;
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
