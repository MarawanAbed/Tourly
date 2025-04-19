using AutoMapper;
using MediatR;
using TravelBookingPortal.Application.Auth.Register.Response;
using TravelBookingPortal.Application.Auth.Register.Services;
using TravelBookingPortal.Domain.Enitites.User;

namespace TravelBookingPortal.Application.Auth.Register.Commands
{
    internal class RegisterCommandHandler(IRegisterService registerService,IMapper mapper) : IRequestHandler<RegisterCommand, RegisterResponse>
    {
        public async Task<RegisterResponse> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {

            var user= mapper.Map<ApplicationUser>(request);
            var result = await registerService.Register(user, request.Password);
            if(result == null)
            {
                return new RegisterResponse
                {
                    Success = false,
                    Token = "null",
                    Id=null

                };
            }
            return new RegisterResponse
            {
                Success = true,
                Token = result,
                Id = user.Id
            };
        }
    }
}
