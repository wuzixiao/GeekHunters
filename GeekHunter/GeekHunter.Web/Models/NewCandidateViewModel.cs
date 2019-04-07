using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeekHunter.Web.Models
{
    public class NewCandidateViewModel
    {
        public NewCandidateViewModel()
        {
            SkillIds = new List<int>();
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public IEnumerable<int> SkillIds { get; set; }
    }
}
