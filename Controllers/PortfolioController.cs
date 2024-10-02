using Microsoft.AspNetCore.Mvc;
using MyPortfolioWebsite.DAL.Context;
using MyPortfolioWebsite.DAL.Entities;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace MyPortfolioWebsite.Controllers
{
    public class PortfolioController : Controller
    {
        PortfolioContext context = new PortfolioContext();
		private readonly PortfolioContext _context;
		private readonly FileUploadService _fileUploadService;

        public IActionResult PortfolioList()
        {
            var values = context.Portfolios.ToList();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreatePortfolio()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreatePortfolio(Portfolio portfolio, IFormFile imageUrl)
        {
			if (imageUrl != null && imageUrl.Length > 0)
			{
				var imagePath = _fileUploadService.UploadFile(imageUrl, "portfolioImages");
				if (imagePath != null)
				{
					// Görsel URL'sini güncelle
					portfolio.imageUrl = imagePath;
				}
			}

			// Portfolio verisini veritabanına kaydetme işlemi
			context.Portfolios.Add(portfolio);
            context.SaveChanges();
            return RedirectToAction("PortfolioList");
        }

        public IActionResult DeletePortfolio(int id)
        {
            var value = context.Portfolios.Find(id);
            context.Portfolios.Remove(value);
            context.SaveChanges();
            return RedirectToAction("PortfolioList");
        }

        [HttpGet]
        public IActionResult UpdatePortfolio(int id)
        {
            var value = context.Portfolios.Find(id);
            return View(value);
        }

        [HttpPost]
        public IActionResult UpdatePortfolio(Portfolio portfolio, IFormFile imageUrl)
        {
			if (imageUrl != null && imageUrl.Length > 0)
			{
				var imagePath = _fileUploadService.UploadFile(imageUrl, "portfolioImages");
				if (imagePath != null)
				{
					// Görsel URL'sini güncelle
					portfolio.imageUrl = imagePath;
				}
			}

			context.Portfolios.Update(portfolio);
            context.SaveChanges();
            return RedirectToAction("PortfolioList");
        }
    }
}
