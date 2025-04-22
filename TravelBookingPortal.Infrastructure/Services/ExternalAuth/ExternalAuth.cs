

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using TravelBookingPortal.Application.Services.ExternalAuth;
using TravelBookingPortal.Application.Services.GenerateJwtToken;
using TravelBookingPortal.Domain.Entites.ExternalAuth;
using TravelBookingPortal.Domain.Entites.User;

namespace TravelBookingPortal.Infrastructure.Services.ExternalAuth
{
    public class ExternalAuthService(SignInManager<ApplicationUser> _signIn, UserManager<ApplicationUser> _userManager, IGenerateJwtToken _generateToken) : IExternalAuthService
    {
        public AuthenticationProperties ConfigureExternalLogin(string provider, string redirectUrl)
        {

            return _signIn.ConfigureExternalAuthenticationProperties(provider, redirectUrl);
        }
        public async Task<ExternalAuthEntities> HandleExternalLoginCallback()
        {
            var info = await _signIn.GetExternalLoginInfoAsync();
            if (info == null)
                throw new Exception("Error loading external login information.");
            var signInResult = await _signIn.ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey, isPersistent: false);
            ApplicationUser user;
            if (signInResult.Succeeded)
            {
                user = await _userManager.FindByLoginAsync(info.LoginProvider, info.ProviderKey);
            }
            else
            {
                var email = info.Principal.FindFirstValue(ClaimTypes.Email);
                if (string.IsNullOrEmpty(email))
                {
                    throw new Exception("Email claim is missing from the external login provider.");
                }

                var firstName = info.Principal.FindFirstValue(ClaimTypes.GivenName) ?? "Unknown";
                var lastName = info.Principal.FindFirstValue(ClaimTypes.Surname) ?? "Unknown";

                user = await _userManager.FindByEmailAsync(email);

                if (user == null)
                {
                    user = new ApplicationUser
                    {
                        UserName = email,
                        Email = email,
                        FirstName = info.Principal.FindFirstValue(ClaimTypes.GivenName) ?? "Unknown",
                        LastName = info.Principal.FindFirstValue(ClaimTypes.Surname) ?? "Unknown",
                        ImageUrl = info.Principal.FindFirstValue("picture") ?? "unknown",
                        CreatedAt = DateTime.UtcNow,
                        PhoneNumber = info.Principal.FindFirstValue(ClaimTypes.MobilePhone) ?? "Unknown",
                        State = info.Principal.FindFirstValue("state") ?? "Unknown",
                        City = info.Principal.FindFirstValue("city") ?? "Unknown",
                        Street = info.Principal.FindFirstValue("street") ?? "Unknown",
                        DateOfBirth = DateTime.TryParse(info.Principal.FindFirstValue("date_of_birth"), out var dob) && dob != default ? dob : DateTime.MinValue,
                    };
                    await _userManager.CreateAsync(user);
                }
                await _userManager.AddLoginAsync(user, info);
            }
            var token = _generateToken.GenerateJwtToken(user);

            return new ExternalAuthEntities
            {
                Token = token,
                UserId = user.Id
            };
        }
    }
}
