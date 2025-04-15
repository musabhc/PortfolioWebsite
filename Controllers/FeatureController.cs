using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyPortfolioWebsite.DAL.Entities;

namespace MyPortfolioWebsite.Controllers
{
    [Authorize(Roles = "Admin")]
    public class FeatureController : Controller
	{
        private readonly PortfolioContext _portfolioContext;
        public FeatureController(PortfolioContext portfolioContext)
        {
            _portfolioContext = portfolioContext;
        }
        public IActionResult FeatureList()
		{
			var values = _portfolioContext.Features.ToList();
			return View(values);
		}
		[HttpGet]
		public IActionResult UpdateFeature(int id)
		{
			var value = _portfolioContext.Experiences.Find(id);
			return View(value);
		}
		[HttpPost]
		public IActionResult UpdateFeature(Feature feature)
		{
			_portfolioContext.Features.Update(feature);
			_portfolioContext.SaveChanges();
			return RedirectToAction("FeatureList");
		}
	}
}
