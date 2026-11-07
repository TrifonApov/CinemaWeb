namespace CinemaApp.Data.Seeding
{
    using Contracts;
    using static GCommon.ExceptionMessages;
    using Microsoft.AspNetCore.Identity;

    public class IdentitySeeder : IIdentitySeeder
    {
        private readonly string[] applicationRoles =
        [
            "Admin",
            "Moderator",
            "User"
        ];  

        private readonly RoleManager<IdentityRole<Guid>> roleManager;

        public IdentitySeeder(RoleManager<IdentityRole<Guid>> roleManager)
        {
            this.roleManager = roleManager;
        }

        public async Task SeedRolesAsync()
        {
            foreach (string applicationRole in applicationRoles)
            {
                bool roleExists = await roleManager.RoleExistsAsync(applicationRole);
                if (!roleExists)
                {
                    IdentityRole<Guid> newRole = new IdentityRole<Guid>(applicationRole);
                    IdentityResult result = await roleManager
                        .CreateAsync(newRole);
                    if (!result.Succeeded)
                    {
                        throw new InvalidOperationException(string.Format(RoleSeedingErrorMessage, applicationRole));
                    }
                }
            }
        }
    }
}
