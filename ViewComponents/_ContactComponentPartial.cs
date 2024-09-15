using Microsoft.AspNetCore.Mvc;
using MyPortfolioWebsite.DAL.Context;

namespace MyPortfolioWebsite.ViewComponents
{
    public class _ContactComponentPartial : ViewComponent
    {
        PortfolioContext portfolioContext = new PortfolioContext();
        public IViewComponentResult Invoke()
        {
            var values = portfolioContext.Contacts.ToList();
            return View(values);
        }
    }
}
