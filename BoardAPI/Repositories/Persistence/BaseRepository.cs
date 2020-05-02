using BoardAPI.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
