using Microsoft.AspNetCore.Mvc;

namespace MyPortfolioWebsite.Controllers
{
    public class LayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
