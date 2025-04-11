using Microsoft.AspNetCore.Mvc;


namespace MyPortfolioWebsite.ViewComponents
{
    public class _FooterComponentPartial : ViewComponent
    {
        private readonly PortfolioContext _portfolioContext;
        public IViewComponentResult Invoke()
        {
            var values = _portfolioContext.SocialMedias.ToList();
            return View(values);
        }
    }
}
