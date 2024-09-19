using Microsoft.AspNetCore.Mvc;

namespace MyPortfolioWebsite.ViewComponents.LayoutViewComponents
{
	public class _LayoutNavbarComponentPartial : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
