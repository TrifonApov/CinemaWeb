namespace CinemaApp.Data.Repository
{
    using System.Linq.Expressions;
    using Contracts;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Models;

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
    }
}
