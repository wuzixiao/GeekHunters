using GeekHunter.Infrastructure.Persistance.Contexts;
using System;
using System.Collections.Generic;
using System.Text;

namespace GeekHunter.Infrastructure.Persistance.Repositories
{
    public abstract class BaseRepository
    {
        protected readonly AppDbContext _context;
        public BaseRepository(AppDbContext context)
        {
            _context = context;
        }
    }
}
