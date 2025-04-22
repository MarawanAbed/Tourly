

using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using TravelBookingPortal.Application.Services.GenerateJwtToken;
using TravelBookingPortal.Application.Services.Register;
using TravelBookingPortal.Domain.Entites.User;

namespace TravelBookingPortal.Infrastructure.Services.Register
{
    public class RegisterService(UserManager<ApplicationUser> _userManager, IGenerateJwtToken _generateToken, ILogger<RegisterService> logger) : IRegisterService
    {
        public async Task<(bool Success, string Token, string Message)> Register(ApplicationUser user, string password)
        {
            var existingUser = await _userManager.FindByEmailAsync(user.Email);
            if (existingUser != null)
            {
                return (false, null,$"User already exists with this email.{user.Email}");
            }
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
                var token = _generateToken.GenerateJwtToken(user);
                return (true, token, "Registration successful.");
            }
            else
            {
                logger.LogWarning("User {Email} registration failed. Errors: {Errors}", users.Email, string.Join(", ", result.Errors.Select(e => e.Description)));
                var errors = string.Join(", ", result.Errors.Select(e => e.Description));
                return (false, null, errors);

            }
        }
    }
}
