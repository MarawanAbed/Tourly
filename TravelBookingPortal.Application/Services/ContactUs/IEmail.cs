namespace TravelBookingPortal.Application.Services.ContactUs
{
    public interface IEmailService
    {
        Task<bool> SendEmailAsync(string to, string subject, string body, string from);
    }
}
