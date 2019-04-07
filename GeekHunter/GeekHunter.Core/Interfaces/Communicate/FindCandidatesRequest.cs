using System;
using System.Collections.Generic;
using System.Text;

namespace GeekHunter.Core.Interfaces.Communicate
{
    public class FindCandidatesRequest
    {
        public IEnumerable<string> SkillNames { get; set; }
    }
}
