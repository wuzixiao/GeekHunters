using GeekHunter.Core.Entities;
using GeekHunter.Core.Interfaces.Communicate;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GeekHunter.Core.Interfaces
{
    public interface ICandidateService
    {
        Task<IEnumerable<Candidate>> GetAllCandidatesAsync();
        Task SaveCandidateAsync(Candidate candidate, IEnumerable<int> ids);
        Task<IEnumerable<Candidate>> FindCandidatesBySkillsAsync(string filter);
        Task<IEnumerable<Candidate>> FindCandidatesByNameAsync(string filter);
    }
}
