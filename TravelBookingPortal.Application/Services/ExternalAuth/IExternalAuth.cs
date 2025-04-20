

using Microsoft.AspNetCore.Authentication;
using TravelBookingPortal.Domain.Entites.ExternalAuth;


namespace TravelBookingPortal.Application.Services.ExternalAuth
{
    public interface IExternalAuthService
    {
        AuthenticationProperties ConfigureExternalLogin(string provider, string redirectUrl);
        Task<ExternalAuthEntities> HandleExternalLoginCallback();
    }
}
