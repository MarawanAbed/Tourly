using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TravelBookingPortal.Domain.Enitites.User;

namespace TravelBookingPortal.Infrastructure.Repositories.AuthRepo
{
    public class GenerateToken(UserManager<ApplicationUser> userManager, IConfiguration configuration, ILogger<GenerateToken> logger) : IGenerateToken
    {
        private readonly UserManager<ApplicationUser> _userManager = userManager;
        private readonly IConfiguration _configuration = configuration;
        private readonly ILogger<GenerateToken> _logger = logger;

        public string GenerateJwtToken(ApplicationUser user)
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
            var roles = _userManager.GetRolesAsync(user).Result;
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            //generate token
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
            issuer: _configuration["Jwt:Issuer"],
            audience: _configuration["Jwt:Audience"],
            claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds);
            _logger.LogInformation("JWT token generated for user {Email}.", user.Email);
            _logger.LogInformation("Token: {Token}", token.ValidTo);
            //return token
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
