using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyPortfolioWebsite.DAL.Entities;

namespace MyPortfolioWebsite.Controllers
{
    [Authorize(Roles = "Admin")]
    public class TestimonialController : Controller
	{
		private readonly PortfolioContext _context;
		private readonly FileUploadService _fileUploadService;
        public TestimonialController(PortfolioContext portfolioContext, FileUploadService fileUploadService)
        {
            _context = portfolioContext;
			_fileUploadService = fileUploadService;
        }
        public IActionResult TestimonialList()
		{
			var values = _context.Testimonials.ToList();
			return View(values);
		}
		[HttpGet]
		public IActionResult CreateTestimonial()
		{
			return View();
		}
		[HttpPost]
		public IActionResult CreateTestimonial(Testimonial testimonial, IFormFile imageUrl)
		{
			var imagePath = _fileUploadService.UploadFile(imageUrl, "testimonialImages");
			if (imagePath != null)
			{
				testimonial.imageUrl = imagePath;
			}

			_context.Testimonials.Add(testimonial);
			_context.SaveChanges();
			return RedirectToAction("TestimonialList");
		}
		public IActionResult DeleteTestimonial(int id)
		{
			var value = _context.Testimonials.Find(id);
			_context.Testimonials.Remove(value);
			_context.SaveChanges();
			return RedirectToAction("TestimonialList");
		}
		[HttpGet]
		public IActionResult UpdateTestimonial(int id)
		{
			var value = _context.Experiences.Find(id);
			return View(value);
		}
		[HttpPost]
		public IActionResult UpdateTestimonial(Testimonial testimonial, IFormFile imageUrl)
		{
			if (imageUrl != null && imageUrl.Length > 0)
			{
				var imagePath = _fileUploadService.UploadFile(imageUrl, "testimonialImages");
				if (imagePath != null)
				{
					// Görsel URL'sini güncelle
					testimonial.imageUrl = imagePath;
				}
			}
			_context.Testimonials.Update(testimonial);
			_context.SaveChanges();
			return RedirectToAction("TestimonialList");
		}
	}
}
