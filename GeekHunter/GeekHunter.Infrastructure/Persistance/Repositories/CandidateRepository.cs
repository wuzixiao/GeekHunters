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
    public class CandidateRepository : BaseRepository,ICandidateRepository
    {
        public CandidateRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Candidate>> GetCandidatesBySkillsAsync(IEnumerable<string> skills)
        {
            if(skills == null || !skills.Any())
            {
                return await _context.Candidates.ToListAsync();
            }
            return await _context.Candidates.Where(c => c.CandidateSkills.Any(cs => skills.Contains(cs.Skill.Name))).ToListAsync();
        }

        public async Task<int> CandidateCount()
        {
            return await _context.Candidates.CountAsync();
        }

        public async Task SaveCandidateAsync(Candidate candidate)
        {
            await _context.Candidates.AddAsync(candidate);
            await _context.SaveChangesAsync();
        }
    }
}
