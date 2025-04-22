using AutoMapper;
using MediatR;
using TravelBookingPortal.Application.Auth.Register.Response;
using TravelBookingPortal.Application.Services.Register;
using TravelBookingPortal.Domain.Entites.User;

namespace TravelBookingPortal.Application.Auth.Register.Commands
{
    internal class RegisterCommandHandler(IRegisterService registerService,IMapper mapper) : IRequestHandler<RegisterCommand, RegisterResponse>
    {
        public async Task<RegisterResponse> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {

            var user= mapper.Map<ApplicationUser>(request);
            var (success, token, message) = await registerService.Register(user, request.Password);
            if (!success)
            {
                return new RegisterResponse
                {
                    Success = false,
                    Token = null,
                    Id = null,
                    ErrorMessage = message // Include the error message in the response
                };
            }

            return new RegisterResponse
            {
                Success = true,
                Token = token,
                Id = user.Id,
                ErrorMessage = null
            };
        }
    }
}
