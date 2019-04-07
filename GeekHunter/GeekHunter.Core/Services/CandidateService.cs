using GeekHunter.Core.Entities;
using GeekHunter.Core.Interfaces;
using GeekHunter.Core.Interfaces.Communicate;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GeekHunter.Core.Services
{
    public class CandidateService : ICandidateService
    {
        private readonly ICandidateRepository _repo;

        public CandidateService(ICandidateRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<Candidate>> FindCandidatesByNameAsync(string filter)
        {
            return await _repo.GetCandidatesByNameAsync(filter);
        }

        public async Task<IEnumerable<Candidate>> FindCandidatesBySkillsAsync(string skill)
        {
            return await _repo.GetCandidatesBySkillsAsync(skill);
        }

        public async Task<IEnumerable<Candidate>> GetAllCandidatesAsync()
        {
            return await _repo.GetCandidatesBySkillsAsync(null);
        }

        public async Task SaveCandidateAsync(Candidate candidate, IEnumerable<int> skillIds)
        {
            await _repo.SaveCandidateAsync(candidate, skillIds);
        }
    }
}
