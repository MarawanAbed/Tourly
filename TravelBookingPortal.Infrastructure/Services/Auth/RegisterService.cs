

using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using TravelBookingPortal.Application.Auth.Register.Services;
using TravelBookingPortal.Application.Auth.Services;
using TravelBookingPortal.Domain.Enitites.User;

namespace TravelBookingPortal.Infrastructure.Services.Auth
{
    public class RegisterService(UserManager<ApplicationUser> _userManager, IGenerateJwtToken _generateToken,ILogger<RegisterService> logger) : IRegisterService
    {
        public async Task<string> Register(ApplicationUser user, string password)
        {
            var users = new ApplicationUser
            {
                UserName = user.UserName,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                ImageUrl = user.ImageUrl,
                PhoneNumber = user.PhoneNumber,
                State = user.State,
                City = user.City,
                DateOfBirth = user.DateOfBirth,
                Street = user.Street,
                CreatedAt = DateTime.UtcNow,
            };
            var result = await _userManager.CreateAsync(user, password);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "User");
                logger.LogInformation("User {Email} registered successfully.", users.Email);
                return _generateToken.GenerateJwtToken(user);
            }
            else
            {
                logger.LogWarning("User {Email} registration failed. Errors: {Errors}", users.Email, string.Join(", ", result.Errors.Select(e => e.Description)));
                throw new Exception(string.Join(", ", result.Errors.Select(e => e.Description)));
            }
        }
    }
}
