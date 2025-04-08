using MediatR;
using TravelBookingPortal.Application.Auth.Register.Response;
using TravelBookingPortal.Domain.Enitites.User;
using TravelBookingPortal.Domain.Repositories.AuthRepo;

namespace TravelBookingPortal.Application.Auth.Register.Commands
{
    internal class RegisterCommandHandler(IRegisterRepoistory registerRepoistory) : IRequestHandler<RegisterCommand, RegisterResponse>
    {
        public async Task<RegisterResponse> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            var ApplicationUser = new ApplicationUser
            {
                Email = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName,
                ImageUrl = request.Image,
                PhoneNumber = request.PhoneNumber,
                State = request.State,
                City = request.City,
                DateOfBirth = request.DateOfBirth,
                Street = request.Street,
                CreatedAt = DateTime.UtcNow
            };
            var result = await registerRepoistory.Register(ApplicationUser,request.Password);
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
