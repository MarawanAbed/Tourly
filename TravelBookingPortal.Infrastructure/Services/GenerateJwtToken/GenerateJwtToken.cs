using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TravelBookingPortal.Application.Services.GenerateJwtToken;
using TravelBookingPortal.Domain.Entites.User;

namespace TravelBookingPortal.Infrastructure.Services.GenerateJwtToken
{
    public class GenerateJwtToken(UserManager<ApplicationUser> userManager, IConfiguration configuration, ILogger<GenerateJwtToken> logger) : IGenerateJwtToken
    {
        string IGenerateJwtToken.GenerateJwtToken(ApplicationUser user)
        {
            //add custom claims
            var claims = new List<Claim>
                {
                    new(ClaimTypes.NameIdentifier, user.Id),
                    new(ClaimTypes.Name, user.UserName),
                    new(ClaimTypes.Email, user.Email),
                    new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };
            //add roles to claims
            var roles = userManager.GetRolesAsync(user).Result;
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            //generate token
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
            issuer: configuration["Jwt:Issuer"],
                audience: configuration["Jwt:Audience"],
            claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds);
            logger.LogInformation("JWT token generated for user {Email}.", user.Email);
            logger.LogInformation("Token: {Token}", token.ValidTo);
            //return token
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
