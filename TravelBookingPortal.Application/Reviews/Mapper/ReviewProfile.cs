
using AutoMapper;
using TravelBookingPortal.Application.Reviews.Commands.CreateReview;
using TravelBookingPortal.Application.Reviews.Dtos;
using TravelBookingPortal.Domain.Entites.Review;


namespace TravelBookingPortal.Application.Reviews.Mapper
{
    public class ReviewProfile :Profile
    {
        public ReviewProfile()
        {
            CreateMap<CreateReviewCommand, ReviewEntities>();
               
            CreateMap<ReviewEntities, ReviewDto>()
    .ForMember(dest => dest.UserImage, opt => opt.MapFrom(src => src.User.ImageUrl))
    .ForMember(dest=>dest.UserName, opt=>opt.MapFrom(src=>src.User.UserName))
    ;
        }
    }
}
