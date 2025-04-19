

using MediatR;
using Microsoft.AspNetCore.Identity;
using TravelBookingPortal.Application.Auth.Login.Response;
using TravelBookingPortal.Application.Auth.Login.Services;
using TravelBookingPortal.Domain.Enitites.User;

namespace TravelBookingPortal.Application.Auth.Login.Commands
{
    public class LoginCommandHandler(ILoginService loginService) : IRequestHandler<LoginCommand, LoginResponse>
    {
        public async Task<LoginResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var token = await loginService.Login(request.Email, request.Password);
            if (token != null)
            {
                return new LoginResponse
                {
                    Token = token,
                    Success = true,
                    Id= await loginService.GetUserId(request.Email)
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
