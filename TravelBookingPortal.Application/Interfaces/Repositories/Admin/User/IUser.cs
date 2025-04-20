using TravelBookingPortal.Domain.Entites.User;

namespace TravelBookingPortal.Application.Interfaces.Repositories.Admin.User
{
    public interface IUserRepository
    {
        Task<IEnumerable<ApplicationUser>> GetAllUsers();

        Task<IEnumerable<ApplicationUser>> GetAllAdmins();

        Task ChangeUserRole(string userId);

        Task DeleteUser(string userId);

    }
}
