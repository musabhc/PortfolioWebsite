using Microsoft.AspNetCore.Mvc;
using MyPortfolioWebsite.DAL.Entities;

namespace MyPortfolioWebsite.Controllers
{
    public class SocialMediaController : Controller
    {

		private readonly PortfolioContext _context;
		private readonly FileUploadService _fileUploadService;
        public SocialMediaController(PortfolioContext portfolioContext, FileUploadService fileUploadService)
        {
            _context = portfolioContext;
            _fileUploadService = fileUploadService;
        }
        public IActionResult SocialMediaList()
        {
            var values = _context.SocialMedias.ToList();
            return View(values);
        }
        [HttpGet]
        public IActionResult CreateSocialMedia()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateSocialMedia(SocialMedia socialmedia, IFormFile icon)
        {
            if (icon != null && icon.Length > 0)
            {
                var imagePath = _fileUploadService.UploadFile(icon, "socialMediaImages");
                if (imagePath != null)
                {
                    // Görsel URL'sini güncelle
                    socialmedia.icon = imagePath;
                }
            }
            else
            {
                // Görsel yüklenmediğinde varsayılan bir ikon URL'si kullanabilirsiniz
                socialmedia.icon = "/images/defaultIcon.ico"; // Varsayılan ikon yolu
            }

            // Portfolio verisini veritabanına kaydetme işlemi
            _context.SocialMedias.Add(socialmedia);
            _context.SaveChanges();
            return RedirectToAction("SocialMediaList");
        }
        public IActionResult DeleteSocialMedia(int id)
        {
            var value = _context.SocialMedias.Find(id);
            _context.SocialMedias.Remove(value);
            _context.SaveChanges();
            return RedirectToAction("SocialMediaList");
        }
        [HttpGet]
        public IActionResult UpdateSocialMedia(int id)
        {
            var value = _context.SocialMedias.Find(id);
            return View(value);
        }
        [HttpPost]
        public IActionResult UpdateSocialMedia(SocialMedia socialmedia, IFormFile icon)
        {
			if (icon != null && icon.Length > 0)
			{
				var imagePath = _fileUploadService.UploadFile(icon, "socialMediaImages");
				if (imagePath != null)
				{
					// Görsel URL'sini güncelle
					socialmedia.icon = imagePath;
				}
            }

            _context.SocialMedias.Update(socialmedia);
            _context.SaveChanges();
            return RedirectToAction("SocialMediaList");
        }
    }
}

