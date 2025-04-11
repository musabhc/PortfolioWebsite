using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace MyPortfolioWebsite.ViewComponents
{
    public class _SkillComponentPartial : ViewComponent
    {
        private readonly PortfolioContext _portfolioContext;
        public IViewComponentResult Invoke()
        {
            var values = _portfolioContext.Skills.ToList();
            return View(values);
        }
    }
}
