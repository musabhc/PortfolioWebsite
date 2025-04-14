using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

using MyPortfolioWebsite.DAL.Entities;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

public class ContactController : Controller
{
    private readonly IConfiguration _configuration;
    private readonly ILogger<ContactController> _logger;
    private readonly PortfolioContext _portfolioContext;
    public ContactController(PortfolioContext portfolioContext, IConfiguration configuration, ILogger<ContactController> logger)
    {
        _portfolioContext = portfolioContext;
        _configuration = configuration;
        _logger = logger;
    }
    public IActionResult ContactList()
	{
		var values = _portfolioContext.Contacts.ToList();
		return View(values);
	}

	[HttpGet]
	public IActionResult UpdateContact(int id)
	{
		var value = _portfolioContext.Contacts.Find(id);
		return View(value);
	}
	[HttpPost]
	public IActionResult UpdateContact(Contact contact)
	{
		_portfolioContext.Contacts.Update(contact);
		_portfolioContext.SaveChanges();
		return RedirectToAction("ContactList");
	}

	// SEND ACTIONS

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
            _portfolioContext.Messages.Add(message);
            _portfolioContext.SaveChanges();
        }
        catch (Exception ex)
        {
            return Json(new { status = "error", message = "Mesaj kaydedilirken bir hata oluştu: " + ex.Message });
        }
        

        return Json(new { status = "OK" });
    }



}
