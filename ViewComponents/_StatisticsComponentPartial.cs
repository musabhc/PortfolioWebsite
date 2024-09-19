using Microsoft.AspNetCore.Mvc;
using MyPortfolioWebsite.DAL.Context;

namespace MyPortfolioWebsite.ViewComponents
{
    public class _StatisticsComponentPartial : ViewComponent
    {
        PortfolioContext portfolioContext = new PortfolioContext();
        public IViewComponentResult Invoke()
        {
            var values = portfolioContext.Statistics.ToList();
            return View(values);
        }
    }
}
