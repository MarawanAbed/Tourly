

using TravelBookingPortal.Domain.Enitites.User;

namespace TravelBookingPortal.Domain.Repositories.AuthRepo
{
    public interface IRegisterRepoistory
    {
        Task<string> Register(ApplicationUser applicationUser,string password);

    }
}
