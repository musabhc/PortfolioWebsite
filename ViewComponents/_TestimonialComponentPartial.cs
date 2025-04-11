using Microsoft.AspNetCore.Mvc;

namespace MyPortfolioWebsite.ViewComponents
{
    public class _TestimonialComponentPartial : ViewComponent
    {
        private readonly PortfolioContext _portfolioContext;
        public IViewComponentResult Invoke()
        {
            var values = _portfolioContext.Testimonials.ToList();
            return View(values);
        }
    }
}
