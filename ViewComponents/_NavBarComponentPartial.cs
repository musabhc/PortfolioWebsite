using Microsoft.AspNetCore.Mvc;

namespace MyPortfolioWebsite.ViewComponents
{
    public class _NavBarComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
