using Microsoft.AspNetCore.Mvc;
using MyPortfolioWebsite.DAL.Context;

namespace MyPortfolioWebsite.Controllers
{
	public class MessageController : Controller
	{
		PortfolioContext context = new PortfolioContext();
		public IActionResult Inbox()
		{
			var values = context.Messages.ToList();
			return View(values);
		}
		public IActionResult ChangeIsRead(int id)
		{
			var value = context.Messages.Find(id).isRead;
			if (value)
			{
				value = false;
			}
			else
			{
				value = true;
			}
			context.SaveChanges();
			return RedirectToAction("Inbox");
		}
		
		public IActionResult DeleteMessage(int id)
		{
			var value = context.Messages.Find(id);
			context.Messages.Remove(value);
			context.SaveChanges();
			return RedirectToAction("Inbox");
		}
		public IActionResult ReadMessage(int id)
		{
			var value = context.Messages.Find(id);
			return View(value);
		}

	}
}
