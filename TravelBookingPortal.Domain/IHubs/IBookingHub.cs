using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelBookingPortal.Domain.IHubs
{
  public  interface IBookingHub
    {
        public Task SendBookingUpdate( string status);
    }
}
