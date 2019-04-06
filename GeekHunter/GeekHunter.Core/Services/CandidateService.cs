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

        public Task<IEnumerable<Candidate>> FindCandidatesBySkills(FindCandidatesRequest request)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Candidate>> GetAllCandidatesAsync()
        {
            return await _repo.GetCandidatesBySkillsAsync(null);
        }

        public Task SaveCandidate(Candidate candidate)
        {
            throw new NotImplementedException();
        }
    }
}
