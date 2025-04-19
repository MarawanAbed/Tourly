

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using TravelBookingPortal.Application.Auth.ExternalAuth.Services;
using TravelBookingPortal.Application.Auth.Services;
using TravelBookingPortal.Domain.Enitites.User;
using TravelBookingPortal.Domain.Enitites.ExternalAuth;

namespace TravelBookingPortal.Infrastructure.Services.Auth
{
    public class ExternalAuthService(SignInManager<ApplicationUser> _signIn, UserManager<ApplicationUser> _userManager, IGenerateJwtToken _generateToken) : IExternalAuthServices
    {
        public AuthenticationProperties ConfigureExternalLogin(string provider, string redirectUrl)
        {

            return _signIn.ConfigureExternalAuthenticationProperties(provider, redirectUrl);
        }
        public async Task<ExternalAuth> HandleExternalLoginCallback()
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
                        DateOfBirth = DateTime.TryParse(info.Principal.FindFirstValue("date_of_birth"), out var dob) && dob != default(DateTime) ? dob : DateTime.MinValue,
                    };
                    await _userManager.CreateAsync(user);
                }
                await _userManager.AddLoginAsync(user, info);
            }
            var token = _generateToken.GenerateJwtToken(user);

            return new ExternalAuth
            {
                Token = token,
                UserId = user.Id
            };
        }
    }
}
