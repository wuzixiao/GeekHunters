using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GeekHunter.Core.Entities
{
    public class Skill
    {
        //would be better put it in DAO layer and map to core
        public Int64 Id { get; set; }
        public String Name { get; set; }
        public ICollection<CandidateSkill> CandidateSkills { get; set; }
    }
}
