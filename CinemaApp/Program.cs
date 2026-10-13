namespace CinemaApp.Web
{
    using CinemaApp.Data;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    public class Program
    {
        public static void Main(string[] args)
        {
            WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            string? connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));
            
            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();
            
            builder.Services.AddControllersWithViews();

            WebApplication app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            app.MapRazorPages();

            app.Run();
        }
        private static void ConfigureIdentityOptions(ConfigurationManager configuration, IdentityOptions options)
        {
            // Password settings
            options.Password.RequireDigit = configuration.GetValue<bool>("Password:RequireDigit");
            options.Password.RequireLowercase = configuration.GetValue<bool>("Password:RequireLowercase");
            options.Password.RequireNonAlphanumeric = configuration.GetValue<bool>("Password:RequireNonAlphanumeric");
            options.Password.RequireUppercase = configuration.GetValue<bool>("Password:RequireUppercase");
            options.Password.RequiredLength = configuration.GetValue<int>("Password:RequiredLength");
            options.Password.RequiredUniqueChars = configuration.GetValue<int>("Password:RequiredUniqueChars")  ;

            //  Sign-in settings
            options.SignIn.RequireConfirmedEmail = configuration.GetValue<bool>("SignIn:RequireConfirmedEmail");
            options.SignIn.RequireConfirmedPhoneNumber = configuration.GetValue<bool>("SignIn:RequireConfirmedPhoneNumber");
            options.SignIn.RequireConfirmedAccount = configuration.GetValue<bool>("SignIn:RequireConfirmedAccount");

            // Lockout settings
            options.Lockout.DefaultLockoutTimeSpan = configuration.GetValue<TimeSpan>("Lockout:DefaultLockoutTimeSpan");
            options.Lockout.MaxFailedAccessAttempts = configuration.GetValue<int>("Lockout:MaxFailedAccessAttempts");
            options.Lockout.AllowedForNewUsers = configuration.GetValue<bool>("Lockout:AllowedForNewUsers");

            // User settings
            options.User.RequireUniqueEmail = configuration.GetValue<bool>("User:RequireUniqueEmail");
        }
    }
}
