namespace CinemaApp.Data.Seeding
{
    using Contracts;
    using static GCommon.ExceptionMessages;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.Configuration;
    using Models;

    public class IdentitySeeder : IIdentitySeeder
    {
        private readonly string[] applicationRoles =
        [
            "Admin",
            "Moderator",
            "User"
        ];

        private readonly RoleManager<IdentityRole<Guid>> roleManager;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IConfiguration configuration;

        public IdentitySeeder(RoleManager<IdentityRole<Guid>> roleManager, UserManager<ApplicationUser> userManager, IConfiguration configuration)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
            this.configuration = configuration;
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

        public async Task SeedAdminUserAsync()
        {
            string adminEmail = configuration["AdminAccount:Email"]
                                ?? throw new InvalidOperationException(AdminUserSeedingEmailNotFoundMessage);
            string adminPassword = configuration["AdminAccount:Password"]
                                   ?? throw new InvalidOperationException(AdminUserSeedingPasswordNotFoundMessage);
            ApplicationUser? adminUser = await userManager
                .FindByEmailAsync(adminEmail);
            if (adminUser == null)
            {
                adminUser = new ApplicationUser()
                {
                    UserName = adminEmail,
                    Email = adminEmail,
                    Birthdate = DateTime.Now.AddYears(-18),
                };

               IdentityResult result = await userManager.CreateAsync(adminUser, adminPassword);
               if (!result.Succeeded)
               {
                   throw new InvalidOperationException(AdminUserSeedingErrorMessage);
               }    

               bool isInRole = await userManager.IsInRoleAsync(adminUser, applicationRoles[0]);
               if (!isInRole)
               {
                   IdentityResult roleResult = await userManager.AddToRoleAsync(adminUser, applicationRoles[0]);
                   if (!roleResult.Succeeded)
                   {
                       throw new InvalidOperationException(AdminUserSeedingErrorMessage);
                   }
               }
            }

        }
    }
}
