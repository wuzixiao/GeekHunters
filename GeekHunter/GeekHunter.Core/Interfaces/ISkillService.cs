﻿using GeekHunter.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GeekHunter.Core.Interfaces
{
    public interface ISkillService
    {
        Task<IEnumerable<Skill>> LoadSkillsAsync();
    }
}
