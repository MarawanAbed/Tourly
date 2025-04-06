

namespace TravelBookingPortal.Domain.Repositories.AuthRepo
{
    public interface IRegisterRepoistory
    {
        Task<string> Register(string email, string password, string firstName, string lastName,string imageUrl);

    }
}
