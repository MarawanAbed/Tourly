

using Microsoft.AspNetCore.Authentication;

namespace TravelBookingPortal.Application.Auth.ExternalAuth.Services
{
    public interface IExternalAuthServices
    {
        AuthenticationProperties ConfigureExternalLogin(string provider, string redirectUrl);
        Task<string> HandleExternalLoginCallback();
    }
}
