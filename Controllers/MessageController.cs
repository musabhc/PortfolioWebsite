using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace MyPortfolioWebsite.Controllers
{
    [Authorize(Roles = "Admin")]
    public class MessageController : Controller
	{
        private readonly PortfolioContext _portfolioContext;
        public MessageController(PortfolioContext portfolioContext)
        {
            _portfolioContext = portfolioContext;
        }
        public IActionResult Inbox()
		{
			var values = _portfolioContext.Messages.ToList();
			return View(values);
		}
		public IActionResult ChangeIsRead(int id)
		{
			var value = _portfolioContext.Messages.Find(id).isRead;
			if (value)
			{
				value = false;
			}
			else
			{
				value = true;
			}
			_portfolioContext.SaveChanges();
			return RedirectToAction("Inbox");
		}
		
		public IActionResult DeleteMessage(int id)
		{
			var value = _portfolioContext.Messages.Find(id);
			_portfolioContext.Messages.Remove(value);
			_portfolioContext.SaveChanges();
			return RedirectToAction("Inbox");
		}
		public IActionResult ReadMessage(int id)
		{
			var value = _portfolioContext.Messages.Find(id);
			return View(value);
		}

	}
}
