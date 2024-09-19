using Microsoft.AspNetCore.Mvc;

namespace MyPortfolioWebsite.ViewComponents.LayoutViewComponents
{
	public class _LayoutHeadComponentPartial : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
