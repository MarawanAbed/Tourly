namespace TravelBookingPortal.Domain.Repositories.AuthRepo
{
    public interface ILoginRepository
    {
        public Task<string?> Login(string email, string password);
    }
}
