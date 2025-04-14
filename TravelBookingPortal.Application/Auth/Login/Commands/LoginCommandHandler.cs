

using MediatR;
using Microsoft.AspNetCore.Identity;
using TravelBookingPortal.Application.Auth.Login.Response;
using TravelBookingPortal.Domain.Enitites.User;
using TravelBookingPortal.Domain.Repositories.AuthRepo;

namespace TravelBookingPortal.Application.Auth.Login.Commands
{
    public class LoginCommandHandler(ILoginRepository loginRepository,UserManager<ApplicationUser> userManager) : IRequestHandler<LoginCommand, LoginResponse>
    {
        public async Task<LoginResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var token = await loginRepository.Login(request.Email, request.Password);
            if (token != null)
            {
                return new LoginResponse
                {
                    Token = token,
                    Success = true,
                    Id= userManager.Users.FirstOrDefault(x => x.Email == request.Email)?.Id
                };
            }
            else
            {
                return new LoginResponse
                {
                    Token = null,
                    Success = false,
                    Id = null
                };
            }
        }
    }
}
