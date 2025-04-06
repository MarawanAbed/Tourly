namespace TravelBookingPortal.Domain.Repositories.Auth
{
    public interface ILoginRepository
    {
        public Task<string?> Login(string email, string password);
    }
}
