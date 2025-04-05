

namespace TravelBookingPortal.Domain.Repositories.Auth
{
    public interface IRegisterRepoistory
    {
        Task<string> Register(string email, string password, string firstName, string lastName,string imageUrl);

    }
}
