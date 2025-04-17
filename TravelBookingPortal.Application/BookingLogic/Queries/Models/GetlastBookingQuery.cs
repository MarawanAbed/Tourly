using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using TravelBookingPortal.Application.BookingLogic.DTOs;
using TravelBookingPortal.Application.CityLogic.Dtos;

namespace TravelBookingPortal.Application.BookingLogic.Queries.Models
{
    public class GetlastBookingQuery : IRequest<GetLastBookingByUserIdDTO>
    {
        public string UserId { get; set; }
        public GetlastBookingQuery(string userId)
        {
            UserId = userId;
        }
    }
}
