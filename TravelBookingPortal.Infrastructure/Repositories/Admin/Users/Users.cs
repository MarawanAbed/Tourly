

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TravelBookingPortal.Domain.Enitites.User;
using TravelBookingPortal.Domain.Repositories.Admin.Users;

namespace TravelBookingPortal.Infrastructure.Repositories.Admin.Users
{
    public class Users(UserManager<ApplicationUser>manager) : IUsers
    {
        public async Task ChangeUserRole(string userId)
        {
            var user = await manager.FindByIdAsync(userId);
            if (user == null)
            {
                throw new Exception("User not found");
            }
            var roles = await manager.GetRolesAsync(user);
            if (roles.Contains("User"))
            {
                await manager.RemoveFromRoleAsync(user, role: "User");
                await manager.AddToRoleAsync(user, "Admin");
            }
        }

        public async Task DeleteUser(string userId)
        {
            var user = await manager.FindByIdAsync(userId);
            if (user == null)
            {
                throw new Exception("User not found");
            }
            var result = await manager.DeleteAsync(user);
            if (!result.Succeeded)
            {
                throw new Exception("Failed to delete user");
            }
        }

        public async Task<IEnumerable<ApplicationUser>> GetAllUsers()
        {
            var users = await manager.Users.ToListAsync();
            var nonAdminUsers = new List<ApplicationUser>();

            foreach (var user in users)
            {
                var roles = await manager.GetRolesAsync(user);
                if (!roles.Contains("Admin"))
                {
                    nonAdminUsers.Add(user);
                }
            }
            return nonAdminUsers;
        }
    }
}
