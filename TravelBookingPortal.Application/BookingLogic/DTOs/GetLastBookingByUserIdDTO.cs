using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelBookingPortal.Application.BookingLogic.DTOs
{
    public class GetLastBookingByUserIdDTO
    {
        public int BookingId { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
