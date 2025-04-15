using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MyPortfolioWebsite.Controllers
{
    [Authorize(Roles = "Admin")]
    public class StatisticController : Controller
    {
        private readonly PortfolioContext _context;
        public StatisticController(PortfolioContext portfolioContext)
        {
            _context = portfolioContext;
        }
        public IActionResult Index()
        {
            ViewBag.v1 = _context.Skills.Count();
            ViewBag.v2 = _context.Messages.Count();
            ViewBag.v3 = _context.Messages.Where(x=> x.isRead == false).Count();
            ViewBag.v4 = _context.Messages.Where(x=> x.isRead == true).Count();

            return View();
        }
    }
}
