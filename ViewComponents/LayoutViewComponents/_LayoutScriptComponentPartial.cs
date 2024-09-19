using Microsoft.AspNetCore.Mvc;

namespace MyPortfolioWebsite.ViewComponents.LayoutViewComponents
{
	public class _LayoutScriptComponentPartial : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
