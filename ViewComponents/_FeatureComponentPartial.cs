using Microsoft.AspNetCore.Mvc;

namespace MyPortfolioWebsite.ViewComponents
{
    public class _FeatureComponentPartial : ViewComponent
    {
        private readonly PortfolioContext _portfolioContext;
        public _FeatureComponentPartial(PortfolioContext portfolioContext)
        {
            _portfolioContext = portfolioContext;
        }
        public IViewComponentResult Invoke()
        {
            var values = _portfolioContext.Features.ToList();
            return View(values);
        }
    }
}
