using System;
using System.Collections.Generic;
using System.Text;

namespace GeekHunter.Core.Entities
{
    public class CandidateSkill
    {
        public Int64 CandidateId { get; set; }
        public Candidate Candidate { get; set; }
        public Int64 SkillId { get; set; }
        public Skill Skill { get; set; }
    }
}
