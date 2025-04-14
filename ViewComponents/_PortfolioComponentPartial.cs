using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace MyPortfolioWebsite.ViewComponents
{
    public class _PortfolioComponentPartial : ViewComponent
    {
        private readonly PortfolioContext _portfolioContext;

        public _PortfolioComponentPartial(PortfolioContext portfolioContext)
        {
            _portfolioContext = portfolioContext;
        }

        public IViewComponentResult Invoke()
        {
            var values = _portfolioContext.Portfolios.ToList();
            return View(values);
        }
    }
}

