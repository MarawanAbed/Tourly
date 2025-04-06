using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelBookingPortal.Application.UserProfile.Dtos;

namespace TravelBookingPortal.Application.UserProfile.Mapper
{
    public partial class UserProfile: Profile
    {
        public UserProfile()
        {
            UserProfileMapping();
        }
      
    }
    
}
