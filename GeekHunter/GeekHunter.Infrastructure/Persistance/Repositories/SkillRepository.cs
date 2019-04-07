using GeekHunter.Core.Entities;
using GeekHunter.Core.Interfaces;
using GeekHunter.Infrastructure.Persistance.Contexts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace GeekHunter.Infrastructure.Persistance.Repositories
{
    public class SkillRepository : BaseRepository, ISkillRepository
    {
        public SkillRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Skill>> GetAllSkilllsAsync()
        {
            return await _context.Skills.ToListAsync();
        }
    }
}
