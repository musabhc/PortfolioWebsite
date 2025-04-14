using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
namespace MyPortfolioWebsite.ViewComponents
{
    public class _ExperienceComponentPartial : ViewComponent
    {
        private readonly PortfolioContext _portfolioContext;

        public _ExperienceComponentPartial(PortfolioContext portfolioContext)
        {
            _portfolioContext = portfolioContext;
        }

        public IViewComponentResult Invoke()
        {
            var values = _portfolioContext.Experiences.ToList();
            return View(values);
        }
    }

}
