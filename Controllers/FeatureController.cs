using Microsoft.AspNetCore.Mvc;
using MyPortfolioWebsite.DAL.Context;
using MyPortfolioWebsite.DAL.Entities;

namespace MyPortfolioWebsite.Controllers
{
	public class FeatureController : Controller
	{
		PortfolioContext context = new PortfolioContext();
		public IActionResult FeatureList()
		{
			var values = context.Features.ToList();
			return View(values);
		}
		[HttpGet]
		public IActionResult UpdateFeature(int id)
		{
			var value = context.Experiences.Find(id);
			return View(value);
		}
		[HttpPost]
		public IActionResult UpdateFeature(Feature feature)
		{
			context.Features.Update(feature);
			context.SaveChanges();
			return RedirectToAction("FeatureList");
		}
	}
}
