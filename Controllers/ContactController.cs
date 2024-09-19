using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

public class ContactController : Controller
{
    private readonly IConfiguration _configuration;
    private readonly ILogger<ContactController> _logger;

    public ContactController(IConfiguration configuration, ILogger<ContactController> logger)
    {
        _configuration = configuration;
        _logger = logger;
    }

    [HttpPost]
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
