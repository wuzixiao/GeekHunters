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
        Task SaveCandidate(Candidate candidate);
        Task<IEnumerable<Candidate>> FindCandidatesBySkills(FindCandidatesRequest request);
    }
}
