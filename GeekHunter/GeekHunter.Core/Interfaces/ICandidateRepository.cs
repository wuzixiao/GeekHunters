using GeekHunter.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GeekHunter.Core.Interfaces
{
    public interface ICandidateRepository
    {
        Task SaveCandidateAsync(Candidate candidate, IEnumerable<int> Ids);
        Task<IEnumerable<Candidate>> GetCandidatesBySkillsAsync(string filter);
        Task<int> CandidateCount();
        Task<IEnumerable<Candidate>> GetCandidatesByNameAsync(string filter);
    }
}
