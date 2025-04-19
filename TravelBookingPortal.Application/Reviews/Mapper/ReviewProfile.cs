using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using TravelBookingPortal.Application.Reviews.DTOs;
using TravelBookingPortal.Domain.Enitites.ReviewEntities;

namespace TravelBookingPortal.Application.Reviews.Mapper
{
    public class ReviewProfile :Profile
    {
        public ReviewProfile()
        {
            CreateMap<CreateReviewDto, Review>();
            CreateMap<Review, ReviewDto>()
    .ForMember(dest => dest.UserImage, opt => opt.MapFrom(src => src.User.ImageUrl))
    .ForMember(dest=>dest.UserName, opt=>opt.MapFrom(src=>src.User.UserName))
    ;
        }
    }
}
