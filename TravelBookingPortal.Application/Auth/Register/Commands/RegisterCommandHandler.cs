using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using TravelBookingPortal.Application.Auth.Register.Response;
using TravelBookingPortal.Domain.Enitites.User;
using TravelBookingPortal.Domain.Repositories.AuthRepo;

namespace TravelBookingPortal.Application.Auth.Register.Commands
{
    internal class RegisterCommandHandler(IRegisterRepoistory registerRepoistory,IMapper mapper,UserManager<ApplicationUser> userManager) : IRequestHandler<RegisterCommand, RegisterResponse>
    {
        public async Task<RegisterResponse> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {

            var user= mapper.Map<ApplicationUser>(request);
            var result = await registerRepoistory.Register(user, request.Password);
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
                Id = userManager.Users.FirstOrDefault(x => x.Email == request.Email)?.Id
            };
        }
    }
}
