using Microsoft.AspNetCore.Mvc;

namespace MyPortfolioWebsite.ViewComponents
{
    public class _AboutComponentPartial : ViewComponent
    {
        private readonly PortfolioContext _portfolioContext;
        public _AboutComponentPartial(PortfolioContext portfolioContext)
        {
            _portfolioContext = portfolioContext;
        }
        public IViewComponentResult Invoke()
        {
            ViewBag.aboutTitle = _portfolioContext.Abouts.Select(x => x.title).FirstOrDefault();
            ViewBag.aboutSubdescription = _portfolioContext.Abouts.Select(x => x.subDescription).FirstOrDefault();
            ViewBag.aboutDetail = _portfolioContext.Abouts.Select(x => x.detail).FirstOrDefault();
            return View();
        }
    }
}
