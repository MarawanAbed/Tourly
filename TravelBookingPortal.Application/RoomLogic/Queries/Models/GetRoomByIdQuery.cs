using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using TravelBookingPortal.Application.RoomLogic.Dtos;

namespace TravelBookingPortal.Application.RoomLogic.Queries.Models
{
   public class GetRoomByIdQuery :IRequest<GetOneRoomDTO>
    {
        public int Id { get; set; }
    }
    
}
