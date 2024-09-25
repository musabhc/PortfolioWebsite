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
        private readonly IWebHostEnvironment _hostingEnvironment;

        // Constructor ile IWebHostEnvironment bağımlılığı ekleyelim.
        public PortfolioController(IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

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
                // Görselin yükleneceği dizin
                var uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "images/portfolioImages");
                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }

                // Dosya ismi ve tam yolu
                var fileName = Path.GetFileName(imageUrl.FileName);
                var filePath = Path.Combine(uploadsFolder, fileName);

                // Dosyanın sunucuya yüklenmesi
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    imageUrl.CopyTo(fileStream);
                }

                // Görsel URL'sini veritabanına kaydetmek için
                portfolio.imageUrl = $"/images/portfolioImages/{fileName}";
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
                // Görselin yükleneceği dizin
                var uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "images/portfolioImages");
                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }

                // Dosya ismi ve tam yolu
                var fileName = Path.GetFileName(imageUrl.FileName);
                var filePath = Path.Combine(uploadsFolder, fileName);

                // Dosyanın sunucuya yüklenmesi
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    imageUrl.CopyTo(fileStream);
                }

                // Görsel URL'sini güncelleme
                portfolio.imageUrl = $"/images/portfolioImages/{fileName}";
            }

            context.Portfolios.Update(portfolio);
            context.SaveChanges();
            return RedirectToAction("PortfolioList");
        }
    }
}
