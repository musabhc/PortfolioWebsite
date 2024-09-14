using Microsoft.AspNetCore.Mvc;

namespace MyPortfolioWebsite.ViewComponents
{
    public class _FeatureComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
