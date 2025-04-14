using Microsoft.AspNetCore.Mvc;

using MyPortfolioWebsite.DAL.Entities;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace MyPortfolioWebsite.Controllers
{
    public class PortfolioController : Controller
    {
        
		private readonly PortfolioContext _context;
		private readonly FileUploadService _fileUploadService;
        public PortfolioController(PortfolioContext portfolioContext, FileUploadService fileUploadService)
        {
            _context = portfolioContext;
            _fileUploadService = fileUploadService;
        }
        public IActionResult PortfolioList()
        {
            var values = _context.Portfolios.ToList();
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
			_context.Portfolios.Add(portfolio);
            _context.SaveChanges();
            return RedirectToAction("PortfolioList");
        }

        public IActionResult DeletePortfolio(int id)
        {
            var value = _context.Portfolios.Find(id);
            _context.Portfolios.Remove(value);
            _context.SaveChanges();
            return RedirectToAction("PortfolioList");
        }

        [HttpGet]
        public IActionResult UpdatePortfolio(int id)
        {
            var value = _context.Portfolios.Find(id);
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

			_context.Portfolios.Update(portfolio);
            _context.SaveChanges();
            return RedirectToAction("PortfolioList");
        }
    }
}
