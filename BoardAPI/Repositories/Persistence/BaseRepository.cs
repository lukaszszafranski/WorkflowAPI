using BoardAPI.Data;

namespace BoardAPI.Repositories.Persistence
{
    public abstract class BaseRepository
    {
        protected readonly BoardAPIContext _context;

        public BaseRepository(BoardAPIContext context)
        {
            _context = context;
        }
    }
}
