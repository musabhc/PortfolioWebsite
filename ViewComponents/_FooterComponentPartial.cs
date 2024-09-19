using Microsoft.AspNetCore.Mvc;
using MyPortfolioWebsite.DAL.Context;

namespace MyPortfolioWebsite.ViewComponents
{
    public class _FooterComponentPartial : ViewComponent
    {
        PortfolioContext portfolioContext = new PortfolioContext();
        public IViewComponentResult Invoke()
        {
            var values = portfolioContext.SocialMedias.ToList();
            return View(values);
        }
    }
}
