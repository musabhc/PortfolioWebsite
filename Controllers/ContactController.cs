using Microsoft.AspNetCore.Mvc;
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
    public async Task<IActionResult> SendEmail(string contactName, string contactEmail, string contactSubject, string contactMessage)
    {
        try
        {
            var smtpClient = new SmtpClient(_configuration["Smtp:Host"])
            {
                Port = int.Parse(_configuration["Smtp:Port"]),
                Credentials = new NetworkCredential(_configuration["Smtp:Username"], _configuration["Smtp:Password"]),
                EnableSsl = true,
            };

            var mailMessage = new MailMessage
            {
                From = new MailAddress("no-reply@yourdomain.com"),
                Subject = contactSubject,
                Body = $"Name: {contactName}\n\nMessage: {contactMessage}",
                IsBodyHtml = false,
            };
            mailMessage.To.Add("info@musabuhurcu.com.tr");

            await smtpClient.SendMailAsync(mailMessage);

            ViewData["SuccessMessage"] = "Your message was sent, thank you!";
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error sending email: {ex.Message}");
            ViewData["ErrorMessage"] = "Something went wrong. Please try again.";
            // Pass form data back to the view
            ViewData["ContactName"] = contactName;
            ViewData["ContactEmail"] = contactEmail;
            ViewData["ContactSubject"] = contactSubject;
            ViewData["ContactMessage"] = contactMessage;
        }

        return View("Contact");
    }

}
