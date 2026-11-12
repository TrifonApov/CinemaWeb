namespace CinemaApp.Data.Repository
{
    using System.Linq.Expressions;
    using Contracts;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Models;
    using static GCommon.OutputMessages.ApplicationUser;

    public class UserRepository : BaseRepository, IUserRepository
    {
        private readonly RoleManager<IdentityRole<Guid>> roleManager;
        private readonly UserManager<ApplicationUser> userManager;

        public UserRepository(CinemaAppDbContext dbContext, RoleManager<IdentityRole<Guid>> roleManager, UserManager<ApplicationUser> userManager) 
            : base(dbContext)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
        }

        public async Task<IEnumerable<ApplicationUser>> GetAllUserAsync(Expression<Func<ApplicationUser, bool>>? filterQuery = null,
            Expression<Func<ApplicationUser, ApplicationUser>>? projectionQuery = null)
        {
            IQueryable<ApplicationUser> applicationUsers = DbContext
                .Users
                .AsNoTracking();

            if (filterQuery != null)
            {
                applicationUsers = applicationUsers
                    .Where(filterQuery);
            }

            if (projectionQuery != null)
            {
                applicationUsers = applicationUsers
                    .Select(projectionQuery);
            }

            IEnumerable<ApplicationUser> appUsers = await applicationUsers
                .OrderBy(u => u.Email)
                .ToArrayAsync();

            return appUsers;
        }

        public async Task<IEnumerable<string>> GetUserRolesAsync(ApplicationUser user)
        {
            IEnumerable<string> userRoles = await userManager.GetRolesAsync(user);

            return userRoles;
        }

        public async Task<bool> UpdateUserRoleAsync(Guid userId, string role, bool removingRole = false)
        {
            ApplicationUser? user = await userManager
                .FindByIdAsync(userId.ToString());

            if (user == null)
            {
                return false;
            }

            bool roleExists = await roleManager.RoleExistsAsync(role);
            if (!roleExists)
            {
                return false;
            }

            bool userAlreadyHasRole = await userManager.IsInRoleAsync(user, role);
            if (userAlreadyHasRole && !removingRole)
            {
                return false;
            }

            if (removingRole && !userAlreadyHasRole)
            {
                return false;
            }


            IdentityResult result;
            if (removingRole)
            {
                result = await userManager
                    .RemoveFromRoleAsync(user, role);
            }
            else
            {
                result = await userManager
                    .AddToRoleAsync(user, role);
            }


            if (!result.Succeeded)
            {
                return false;
            }

            return true;
        }

        public async Task<bool> DeleteUserAsync(Guid userId)
        {
            ApplicationUser? user = await userManager
                .FindByIdAsync(userId.ToString());

            if (user == null)
            {
                return false;
            }

            IdentityResult result = await userManager
                .DeleteAsync(user);

            if (!result.Succeeded)
            {
                return false;
            }

            return true;
        }
    }
}
