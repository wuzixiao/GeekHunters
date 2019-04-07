using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GeekHunter.Core.Entities;
using GeekHunter.Core.Interfaces;
using GeekHunter.Core.Interfaces.Communicate;
using GeekHunter.Web.Mappers;
using GeekHunter.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GeekHunter.Web.Controllers
{
    public class CandidatesController : Controller
    {
        private readonly ICandidateService _candidateService;
        private readonly ISkillService _skillService;

        public CandidatesController(ICandidateService candidateService, ISkillService skillService)
        {
            _candidateService = candidateService;
            _skillService = skillService;
        }

        public async Task<ActionResult> Search(string name, string skill)
        {
            IEnumerable<Candidate> candidates;
            if(!String.IsNullOrEmpty(name))
            {
                candidates = await _candidateService.FindCandidatesByNameAsync(name);
            }
            else
            {
                candidates = await _candidateService.FindCandidatesBySkillsAsync(skill);
            }

            return View(candidates);
        }

        // GET: Candidates/Create
        public async Task<ActionResult> Create()
        {
            //Todo : use tempdata will be better
            ViewBag.Skills = await _skillService.LoadSkillsAsync(); 
            return View();
        }

        public ActionResult CreateSuccess()
        {
            return View();
        }

        // POST: Candidates/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(NewCandidateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                //log
                ViewBag.Skills = await _skillService.LoadSkillsAsync();  //TODO : avoid it by using presentator on the view
                return View();
            }
            try
            {
                await _candidateService.SaveCandidateAsync(
                    new Core.Entities.Candidate
                        {
                            FirstName = model.FirstName,
                            LastName = model.LastName,
                        }, 
                    model.SkillIds
                );

                return RedirectToAction(nameof(CreateSuccess), model);
            }
            catch(Exception ex)
            {
                //add log exception
                return View();
            }
        }
    }
}