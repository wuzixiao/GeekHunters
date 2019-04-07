using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeekHunter.Web.Models
{
    public class NewCandidateViewModelValidation : AbstractValidator<NewCandidateViewModel>
    {
        public NewCandidateViewModelValidation()
        {
            RuleFor(x => x.FirstName).NotNull();
            RuleFor(x => x.LastName).NotNull();
            RuleFor(x => x.FirstName).Length(1, 30);
            RuleFor(x => x.LastName).Length(1, 30);
            RuleFor(x => x.SkillIds).Must(s => s != null && s.Count() > 0).WithMessage("Please select as least one skill");
        }
    }
}
