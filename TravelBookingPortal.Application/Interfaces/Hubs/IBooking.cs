namespace TravelBookingPortal.Application.Interfaces.Hubs
{
    public interface IBookingHub
    {
        public Task SendBookingUpdate(string status);
    }
}
