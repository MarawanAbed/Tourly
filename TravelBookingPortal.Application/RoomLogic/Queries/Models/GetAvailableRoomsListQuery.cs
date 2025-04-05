using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using TravelBookingPortal.Application.RoomLogic.Dtos;
using TravelBookingPortal.Domain.Enitites.RoomEntities;

namespace TravelBookingPortal.Application.RoomLogic.Queries.Models
{
   public class GetAvailableRoomsListQuery : IRequest<IEnumerable<GetRoomsDTO>>
    {
        public string City { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public string RoomType { get; set;}

    }
}
