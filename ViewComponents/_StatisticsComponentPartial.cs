using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace MyPortfolioWebsite.ViewComponents
{
    public class _StatisticsComponentPartial : ViewComponent
    {
        private readonly PortfolioContext _portfolioContext;
        public IViewComponentResult Invoke()
        {
            var values = _portfolioContext.Statistics.ToList();
            return View(values);
        }
    }
}
