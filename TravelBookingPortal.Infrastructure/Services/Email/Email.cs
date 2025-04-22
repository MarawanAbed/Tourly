using System.Net.Mail;
using System.Net;
using Microsoft.Extensions.Configuration;
using TravelBookingPortal.Application.Services.ContactUs;

namespace TravelBookingPortal.Infrastructure.Services.Email
{
    public class EmailService(IConfiguration configuration) : IEmailService
    {
        public async Task<bool> SendEmailAsync(string to, string subject, string body, string from)
        {
            try
            {
                var smtpClient = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587,
                    Credentials = new NetworkCredential(
                        configuration["EmailSettings:FromEmail"],
                        configuration["EmailSettings:AppPassword"]
                    ),
                    EnableSsl = true,
                };

                var mailMessage = new MailMessage
                {
                    From = new MailAddress(configuration["EmailSettings:FromEmail"], "Tourly Contact Form"),
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = false
                };
                mailMessage.To.Add(to);
                mailMessage.ReplyToList.Add(new MailAddress(from));

                await smtpClient.SendMailAsync(mailMessage);
                return true;
            }
            catch (Exception ex)
            {

                Console.WriteLine("Email send failed: " + ex.Message);
                return false;
            }
        }

    }
}