using MediatR;
using TravelBookingPortal.Application.Auth.Register.Response;
using TravelBookingPortal.Domain.Repositories.Auth;

namespace TravelBookingPortal.Application.Auth.Register.Commands
{
    internal class RegisterCommandHandler(IRegisterRepoistory registerRepoistory) : IRequestHandler<RegisterCommand, RegisterResponse>
    {
        public async Task<RegisterResponse> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            var result = await registerRepoistory.Register(request.Email, request.Password, request.FirstName, request.LastName, request.Image);
            if(result == null)
            {
                return new RegisterResponse
                {
                    Success = false,
                    Token = "null"
                };
            }
            return new RegisterResponse
            {
                Success = true,
                Token = result
            };
        }
    }
}
