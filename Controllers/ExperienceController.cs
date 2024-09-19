using Microsoft.AspNetCore.Mvc;
using MyPortfolioWebsite.DAL.Context;

namespace MyPortfolioWebsite.Controllers
{
    public class ExperienceController : Controller
    {
        PortfolioContext context = new PortfolioContext();
        public IActionResult ExperinceList()
        {
            var values = context.Experiences.ToList();
            return View(values);
        }
    }
}
