using TravelBookingPortal.Domain.Enitites.User;

namespace TravelBookingPortal.Domain.Repositories.Admin.Users
{
    public interface IUsers
    {
        Task<IEnumerable<ApplicationUser>> GetAllUsers();

        Task<IEnumerable<ApplicationUser>> GetAllAdmins();

        Task ChangeUserRole(string userId);

        Task DeleteUser(string userId);

    }
}
