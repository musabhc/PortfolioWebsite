using Microsoft.AspNetCore.Mvc;

namespace MyPortfolioWebsite.ViewComponents
{
    public class _ContactComponentPartial : ViewComponent
    {
        private readonly PortfolioContext _portfolioContext;
        public _ContactComponentPartial(PortfolioContext portfolioContext)
        {
            _portfolioContext = portfolioContext;
        }
        public IViewComponentResult Invoke()
        {
            var values = _portfolioContext.Contacts.ToList();
            return View(values);
        }
    }
}
