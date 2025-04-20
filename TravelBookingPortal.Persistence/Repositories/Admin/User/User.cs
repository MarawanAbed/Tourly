

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TravelBookingPortal.Application.Interfaces.Repositories.Admin.User;
using TravelBookingPortal.Domain.Entites.User;

namespace TravelBookingPortal.Persistence.Repositories.Admin.User
{
    public class UserRepository(UserManager<ApplicationUser> manager) : IUserRepository
    {
        public async Task ChangeUserRole(string userId)
        {
            var user = await manager.FindByIdAsync(userId) ?? throw new Exception("User not found");
            var roles = await manager.GetRolesAsync(user);
            if (roles.Contains("User"))
            {
                await manager.RemoveFromRoleAsync(user, role: "User");
                await manager.AddToRoleAsync(user, "Admin");
            }
        }

        public async Task DeleteUser(string userId)
        {
            var user = await manager.FindByIdAsync(userId) ?? throw new Exception("User not found");
            var result = await manager.DeleteAsync(user);
            if (!result.Succeeded)
            {
                throw new Exception("Failed to delete user");
            }
        }

        public async Task<IEnumerable<ApplicationUser>> GetAllAdmins()
        {
            var users = await manager.Users.ToListAsync();
            var adminUsers = new List<ApplicationUser>();
            foreach (var user in users)
            {
                var roles = await manager.GetRolesAsync(user);
                if (roles.Contains("Admin"))
                {
                    adminUsers.Add(user);
                }
            }
            return adminUsers;
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
