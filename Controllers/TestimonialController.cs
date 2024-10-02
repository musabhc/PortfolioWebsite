using Microsoft.AspNetCore.Mvc;
using MyPortfolioWebsite.DAL.Context;
using MyPortfolioWebsite.DAL.Entities;

namespace MyPortfolioWebsite.Controllers
{
	public class TestimonialController : Controller
	{
		PortfolioContext context = new PortfolioContext();
		private readonly PortfolioContext _context;
		private readonly FileUploadService _fileUploadService;

		public IActionResult TestimonialList()
		{
			var values = context.Testimonials.ToList();
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
			var value = context.Testimonials.Find(id);
			context.Testimonials.Remove(value);
			context.SaveChanges();
			return RedirectToAction("TestimonialList");
		}
		[HttpGet]
		public IActionResult UpdateTestimonial(int id)
		{
			var value = context.Experiences.Find(id);
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
			context.Testimonials.Update(testimonial);
			context.SaveChanges();
			return RedirectToAction("TestimonialList");
		}
	}
}
