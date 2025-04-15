using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using MyPortfolioWebsite.DAL.Entities;

namespace MyPortfolioWebsite.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ExperienceController : Controller
    {
        private readonly PortfolioContext _portfolioContext;
        public ExperienceController(PortfolioContext portfolioContext)
        {
            _portfolioContext = portfolioContext;
        }
        public IActionResult ExperienceList()
        {
            var values = _portfolioContext.Experiences.ToList();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateExperience()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateExperience(Experience experience)
        {
            _portfolioContext.Experiences.Add(experience);
            _portfolioContext.SaveChanges();
            return RedirectToAction("ExperienceList");
        }

        public IActionResult DeleteExperience(int id)
        {
            var value = _portfolioContext.Experiences.Find(id);
            _portfolioContext.Experiences.Remove(value);
            _portfolioContext.SaveChanges();
            return RedirectToAction("ExperienceList");
        }

        [HttpGet]
        public IActionResult UpdateExperience(int id)
        {
            var value = _portfolioContext.Experiences.Find(id);
            return View(value);
        }

        [HttpPost]
        public IActionResult UpdateExperience(Experience experience)
        {

            _portfolioContext.Experiences.Update(experience);
            _portfolioContext.SaveChanges();
            return RedirectToAction("ExperienceList");
        }
    }
}
