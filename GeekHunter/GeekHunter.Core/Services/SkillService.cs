using GeekHunter.Core.Entities;
using GeekHunter.Core.Interfaces;
using GeekHunter.Core.Interfaces.Communicate;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GeekHunter.Core.Services
{
    public class SkillService : ISkillService
    {
        private readonly ISkillRepository _repo;

        public SkillService(ISkillRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<Skill>> LoadSkillsAsync()
        {
            return await _repo.GetAllSkilllsAsync();
        }
    }
}
