using Microsoft.AspNetCore.Mvc;

namespace MyPortfolioWebsite.ViewComponents
{
    public class _MessageComponentPartial : ViewComponent
    {
        private readonly PortfolioContext _portfolioContext;
        public _MessageComponentPartial(PortfolioContext portfolioContext)
        {
            _portfolioContext = portfolioContext;
        }
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
