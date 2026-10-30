using CinemaApp.Services.Core;
using CinemaApp.Services.Core.Contracts;

namespace CinemaApp.Web
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using CinemaApp.Data;
    using CinemaApp.Services.AutoMapping;
    using CinemaApp.Data.Repository;
    using CinemaApp.Services.Models.Movie;
    using CinemaApp.Web.Infrastructure.Extensions;
    using CinemaApp.Web.ViewModels.Movie;


    public class Program
    {
        public static void Main(string[] args)
        {
            WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            string? connectionString = builder
                .Configuration
                .GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            
            AutoMapperConfig.RegisterMappings(typeof(MovieAllDto).Assembly, typeof(AllMoviesIndexViewModel).Assembly);

            builder.Services.AddDbContext<CinemaAppDbContext>(options =>
                options.UseSqlServer(connectionString));
            
            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            builder.Services.RegisterRepositories(typeof(MovieRepository));

            builder.Services.RegisterUserServices(typeof(MovieService));

            //builder.Services.AddScoped<IMovieRepository, MovieRepository>();
            //builder.Services.AddScoped<IWatchlistRepository, WatchlistRepository>();

            //builder.Services.AddScoped<IMovieService, MovieService>();
            //builder.Services.AddScoped<IWatchlistService, WatchlistService>();

            builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<CinemaAppDbContext>();

            builder.Services.AddControllersWithViews();

            builder.Services.AddSingleton(AutoMapperConfig.MapperInstance);

            builder.Services.Configure<IdentityOptions>(options =>
            {
                ConfigureIdentityOptions(builder.Configuration, options);
            });

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
            
            app.UseStatusCodePagesWithRedirects("/Home/Error/{0}");

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
            options.Password.RequireDigit = configuration.GetValue<bool>("Identity:Password:RequireDigit");
            options.Password.RequireLowercase = configuration.GetValue<bool>("Identity:Password:RequireLowercase");
            options.Password.RequireNonAlphanumeric = configuration.GetValue<bool>("Identity:Password:RequireNonAlphanumeric");
            options.Password.RequireUppercase = configuration.GetValue<bool>("Identity:Password:RequireUppercase");
            options.Password.RequiredLength = configuration.GetValue<int>("Identity:Password:RequiredLength");
            options.Password.RequiredUniqueChars = configuration.GetValue<int>("Identity:Password:RequiredUniqueChars")  ;

            //  Sign-in settings
            options.SignIn.RequireConfirmedEmail = configuration.GetValue<bool>("Identity:SignIn:RequireConfirmedEmail");
            options.SignIn.RequireConfirmedPhoneNumber = configuration.GetValue<bool>("Identity:SignIn:RequireConfirmedPhoneNumber");
            options.SignIn.RequireConfirmedAccount = configuration.GetValue<bool>("Identity:SignIn:RequireConfirmedAccount");

            // Lockout settings
            options.Lockout.DefaultLockoutTimeSpan = configuration.GetValue<TimeSpan>("Identity:Lockout:DefaultLockoutTimeSpan");
            options.Lockout.MaxFailedAccessAttempts = configuration.GetValue<int>("Identity:Lockout:MaxFailedAccessAttempts");
            options.Lockout.AllowedForNewUsers = configuration.GetValue<bool>("Identity:Lockout:AllowedForNewUsers");

            // User settings
            options.User.RequireUniqueEmail = configuration.GetValue<bool>("Identity:User:RequireUniqueEmail");
        }
    }
}
