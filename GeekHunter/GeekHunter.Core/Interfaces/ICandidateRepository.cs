using GeekHunter.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GeekHunter.Core.Interfaces
{
    public interface ICandidateRepository
    {
        Task SaveCandidateAsync(Candidate candidate);
        Task<IEnumerable<Candidate>> GetCandidatesBySkillsAsync(IEnumerable<string> skills);
        Task<int> CandidateCount();
    }
}
