using AutoMapper;
using GeekHunter.Core.Entities;
using GeekHunter.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Linq;
using GeekHunter.Infrastructure.Persistance.Contexts;

namespace GeekHunter.Web.Mappers
{
    //public class CandidateMapper : Profile
    //{
    //    public CandidateMapper()
    //    {
    //        CreateMap<NewCandidateViewModel, Candidate>()
    //            .ForMember(d => d.CandidateSkills, opt => opt.MapFrom<CustomResolver, IEnumerable<CandidateSkill>>(src => src.SkillNames));
    //    }

    //    public class CustomResolver : IValueResolver<IEnumerable<string>, IEnumerable<CandidateSkill>, IEnumerable<CandidateSkill>>
    //    {
    //        public IEnumerable<CandidateSkill> Resolve(IEnumerable<string> source, IEnumerable<CandidateSkill> destination, IEnumerable<CandidateSkill> destMember, ResolutionContext context)
    //        {
    //            throw new NotImplementedException();
    //        }
    //    }
    //}
}
