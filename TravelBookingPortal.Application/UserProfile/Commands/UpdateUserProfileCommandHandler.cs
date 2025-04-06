using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TravelBookingPortal.Application.UserProfile.Dtos;
using TravelBookingPortal.Domain.Enitites.PreferenceEnitites;
using TravelBookingPortal.Domain.Enitites.User;
using TravelBookingPortal.Domain.Repositories.Profile;

namespace TravelBookingPortal.Application.UserProfile.Commands
{
    public class UpdateUserProfileCommandHandler: IRequestHandler<UpdateUserProfileCommand, bool>
    { private readonly IProfileRepo _profileRepo;
        private readonly IMapper mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<ApplicationUser> _userManager;


        public UpdateUserProfileCommandHandler(IProfileRepo profileRepo, UserManager<ApplicationUser> userManager, IMapper mapper,IHttpContextAccessor httpContextAccessor)
        {
            _profileRepo = profileRepo;
            this.mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
        }
        public  async Task<bool> Handle(UpdateUserProfileCommand request, CancellationToken cancellationToken)
        {
            var userID = _userManager.GetUserId(_httpContextAccessor.HttpContext.User);
            if (userID == null)
            {
                return false;
            }

            var preferencesList = mapper.Map<List<Preference>>(request.Preferences ?? new List<PreferenceDto>());
          await  _profileRepo.UpdateUserProfileAsync(userID, request.FirstName,request.LastName,request.ImageUrl,request.PhoneNumber,request.State,request.City,request.Street, preferencesList);

            return true;

        }
    }
    
}
