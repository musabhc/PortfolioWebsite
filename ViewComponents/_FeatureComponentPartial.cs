using Microsoft.AspNetCore.Mvc;

namespace MyPortfolioWebsite.ViewComponents
{
    public class _FeatureComponentPartial : ViewComponent
    {
        private readonly PortfolioContext _portfolioContext;
        public IViewComponentResult Invoke()
        {
            var values = _portfolioContext.Features.ToList();
            return View(values);
        }
    }
}
