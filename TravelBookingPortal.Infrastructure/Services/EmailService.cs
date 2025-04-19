using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using TravelBookingPortal.Domain.Repositories.ContuctUs;

namespace TravelBookingPortal.Infrastructure.Services
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _configuration;

        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<bool> SendEmailAsync(string to, string subject, string body, string from)
        {
            try
            {
                var smtpClient = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587,
                    Credentials = new NetworkCredential(
                        _configuration["EmailSettings:FromEmail"],
                        _configuration["EmailSettings:AppPassword"]
                    ),
                    EnableSsl = true,
                };

                var mailMessage = new MailMessage
                {
                    From = new MailAddress(from),
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = false
                };
                mailMessage.To.Add(to);

                await smtpClient.SendMailAsync(mailMessage);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
