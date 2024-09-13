using Microsoft.AspNetCore.Mvc;

namespace PortfolioWebsite.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
