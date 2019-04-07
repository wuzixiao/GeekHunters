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
    public class CandidateRepository : BaseRepository, ICandidateRepository
    {
        public CandidateRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Candidate>> GetCandidatesByNameAsync(string filter)
        {
            if(String.IsNullOrEmpty(filter))
            {
                return await _context.Candidates
                    .Include(cs => cs.CandidateSkills)
                    .ThenInclude(cs => cs.Skill)
                    .ToListAsync();
            }
            return await _context.Candidates
                .Where(c => c.CandidateSkills.Any(cs => cs.Candidate.FirstName.Equals(filter, StringComparison.CurrentCultureIgnoreCase) 
                                                        || cs.Candidate.LastName.Equals(filter, StringComparison.CurrentCultureIgnoreCase)))
                .Include(cs => cs.CandidateSkills)
                .ThenInclude(cs => cs.Skill)
                .ToListAsync();
        }

        public async Task<IEnumerable<Candidate>> GetCandidatesBySkillsAsync(string filter)
        {
            if(String.IsNullOrEmpty(filter))
            {
                return await _context.Candidates
                    .Include(cs => cs.CandidateSkills)
                    .ThenInclude(cs => cs.Skill)
                    .ToListAsync();
            }
            return await _context.Candidates
                .Where(c => c.CandidateSkills.Any(cs => cs.Skill.Name.Equals(filter, StringComparison.CurrentCultureIgnoreCase)))
                .Include(cs => cs.CandidateSkills)
                .ThenInclude(cs => cs.Skill)
                .ToListAsync();
        }

        public async Task<int> CandidateCount()
        {
            return await _context.Candidates.CountAsync();
        }

        public async Task SaveCandidateAsync(Candidate candidate, IEnumerable<int> skillIds)
        {
            candidate.CandidateSkills = skillIds.Select(id => new CandidateSkill
            {
                Candidate = candidate,
                Skill = _context.Skills.Single(s => s.Id == id)
            }).ToList();

            await _context.Candidates.AddAsync(candidate);

            await _context.SaveChangesAsync();
        }
    }
}
