

using MediatR;
using TravelBookingPortal.Application.Auth.Login.Response;
using TravelBookingPortal.Domain.Repositories.AuthRepo;

namespace TravelBookingPortal.Application.Auth.Login.Commands
{
    public class LoginCommandHandler(ILoginRepository loginRepository) : IRequestHandler<LoginCommand, LoginResponse>
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
                };
            }
            else
            {
                return new LoginResponse
                {
                    Token = null,
                    Success = false,
                };
            }
        }
    }
}
