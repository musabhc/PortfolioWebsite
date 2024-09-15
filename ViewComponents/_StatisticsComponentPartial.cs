using Microsoft.AspNetCore.Mvc;
using MyPortfolioWebsite.DAL.Context;

namespace MyPortfolioWebsite.ViewComponents
{
    public class _StatisticsComponentPartial : ViewComponent
    {
        PortfolioContext portfolioContext = new PortfolioContext();
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
