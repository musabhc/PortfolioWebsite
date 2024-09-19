using Microsoft.AspNetCore.Mvc;

namespace MyPortfolioWebsite.ViewComponents.LayoutViewComponents
{
	public class _LayoutSidebarComponentPartial : ViewComponent
	{
		public IViewComponentResult Invoke() { 
			return View();
		}
	}
}
