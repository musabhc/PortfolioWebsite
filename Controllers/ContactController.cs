using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MyPortfolioWebsite.DAL.Context;
using MyPortfolioWebsite.DAL.Entities;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

public class ContactController : Controller
{
    private readonly IConfiguration _configuration;
    private readonly ILogger<ContactController> _logger;
	PortfolioContext context = new PortfolioContext();
	public IActionResult ContactList()
	{
		var values = context.Contacts.ToList();
		return View(values);
	}

	[HttpGet]
	public IActionResult UpdateContact(int id)
	{
		var value = context.Contacts.Find(id);
		return View(value);
	}
	[HttpPost]
	public IActionResult UpdateContact(Contact contact)
	{
		context.Contacts.Update(contact);
		context.SaveChanges();
		return RedirectToAction("ContactList");
	}

	// SEND ACTIONS
	public ContactController(IConfiguration configuration, ILogger<ContactController> logger)
    {
        _configuration = configuration;
        _logger = logger;
    }

    [HttpPost]
    public IActionResult SendEmail(string contactName, string contactEmail, string contactSubject, string contactMessage)
    {
        if (string.IsNullOrEmpty(contactName) || string.IsNullOrEmpty(contactEmail) || string.IsNullOrEmpty(contactMessage))
        {
            return Json(new { status = "error", message = "Lütfen tüm zorunlu alanları doldurun." });
        }
        // Message nesnesi oluşturma
        var message = new Message
        {
            nameSurname = contactName,
            email = contactEmail,
            subject = contactSubject,
            messageDetail = contactMessage,
            sendDate = DateTime.Now,
            isRead = false // Varsayılan olarak okunmadı
        };

        try
        {
            context.Messages.Add(message);
            context.SaveChanges();
        }
        catch (Exception ex)
        {
            return Json(new { status = "error", message = "Mesaj kaydedilirken bir hata oluştu: " + ex.Message });
        }
        

        return Json(new { status = "OK" });
    }



}
