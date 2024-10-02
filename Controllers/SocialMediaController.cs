using Microsoft.AspNetCore.Mvc;
using MyPortfolioWebsite.DAL.Context;
using MyPortfolioWebsite.DAL.Entities;

namespace MyPortfolioWebsite.Controllers
{
    public class SocialMediaController : Controller
    {
        PortfolioContext context = new PortfolioContext();
		private readonly PortfolioContext _context;
		private readonly FileUploadService _fileUploadService;
		public IActionResult SocialMediaList()
        {
            var values = context.SocialMedias.ToList();
            return View(values);
        }
        [HttpGet]
        public IActionResult CreateSocialMedia()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateSocialMedia(SocialMedia socialmedia, IFormFile imageUrl)
        {
		var imagePath = _fileUploadService.UploadFile(imageUrl, "socialMediaImages");
		if (imagePath != null)
		{
			// Görsel URL'sini güncelle
			socialmedia.icon = imagePath;
		}
			
			context.SocialMedias.Add(socialmedia);
            context.SaveChanges();
            return RedirectToAction("SocialMediaList");
        }
        public IActionResult DeleteSocialMedia(int id)
        {
            var value = context.SocialMedias.Find(id);
            context.SocialMedias.Remove(value);
            context.SaveChanges();
            return RedirectToAction("SocialMediaList");
        }
        [HttpGet]
        public IActionResult UpdateSocialMedia(int id)
        {
            var value = context.SocialMedias.Find(id);
            return View(value);
        }
        [HttpPost]
        public IActionResult UpdateSocialMedia(SocialMedia socialmedia, IFormFile imageUrl)
        {
			if (imageUrl != null && imageUrl.Length > 0)
			{
				var imagePath = _fileUploadService.UploadFile(imageUrl, "socialMediaImages");
				if (imagePath != null)
				{
					// Görsel URL'sini güncelle
					socialmedia.icon = imagePath;
				}
			}
			context.SocialMedias.Update(socialmedia);
            context.SaveChanges();
            return RedirectToAction("SocialMediaList");
        }
    }
}

