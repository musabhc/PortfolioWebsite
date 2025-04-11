using Microsoft.AspNetCore.Mvc;

namespace MyPortfolioWebsite.ViewComponents
{
    public class _ContactComponentPartial : ViewComponent
    {
        private readonly PortfolioContext _portfolioContext;
        public IViewComponentResult Invoke()
        {
            var values = _portfolioContext.Contacts.ToList();
            return View(values);
        }
    }
}
