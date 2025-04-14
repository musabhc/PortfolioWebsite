using Microsoft.AspNetCore.Mvc;

using MyPortfolioWebsite.DAL.Entities;

namespace MyPortfolioWebsite.Controllers
{
    public class AboutController : Controller
    {
        private readonly PortfolioContext _portfolioContext;
        public AboutController(PortfolioContext portfolioContext)
        {
            _portfolioContext = portfolioContext;
        }
        public IActionResult AboutList()
        {
            var values = _portfolioContext.Abouts.ToList();
            return View(values);
        }
		[HttpGet]
		public IActionResult UpdateAbout(int id)
		{
			var value = _portfolioContext.Abouts.Find(id);
			return View(value);
		}
		[HttpPost]
		public IActionResult UpdateAbout(About about)
		{
			_portfolioContext.Abouts.Update(about);
			_portfolioContext.SaveChanges();
			return RedirectToAction("AboutList");
		}

	}
}
