using BoardAPI.Data;

namespace BoardAPI.Repositories.Persistence
{
    public abstract class BaseRepository
    {
        protected readonly WorkflowAPIContext _context;

        public BaseRepository(WorkflowAPIContext context)
        {
            _context = context;
        }
    }
}
