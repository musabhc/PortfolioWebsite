using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MyPortfolioWebsite.Controllers
{
    [Authorize(Roles = "Admin")]
    public class LayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
