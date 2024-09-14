using Microsoft.AspNetCore.Mvc;

namespace MyPortfolioWebsite.ViewComponents
{
    public class _ExperienceComponentPartial  : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
