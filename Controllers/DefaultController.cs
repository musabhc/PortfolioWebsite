using Microsoft.AspNetCore.Mvc;

namespace MyPortfolioWebsite.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
