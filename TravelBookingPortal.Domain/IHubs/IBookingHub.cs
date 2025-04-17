

namespace TravelBookingPortal.Domain.IHubs
{
  public  interface IBookingHub
    {
        public Task SendBookingUpdate( string status);
    }
}
