namespace CinemaApp.IntegrationTests
{
    using Data;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc.Testing;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;

    public class CinemaAppWebApplicationFactory<TProgram> : WebApplicationFactory<TProgram> 
        where TProgram : class
    {
        private readonly string inMemoryDatabaseName = $"InMemory_CinemaApp_{Guid.NewGuid()}";
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                // Remove the original DbContext registration
                ServiceDescriptor? descriptor = services.SingleOrDefault(
                    d => d.ServiceType ==
                        typeof(DbContextOptions<CinemaAppDbContext>));

                if (descriptor != null)
                {
                    services.Remove(descriptor);
                }

                // Add a new DbContext registration for testing
                services.AddDbContext<CinemaAppDbContext>(options =>
                {
                    options.UseInMemoryDatabase(inMemoryDatabaseName, b=>b.EnableNullChecks(false));
                });

                // Build the service provider and ensure the database is created
                ServiceProvider sp = services.BuildServiceProvider();
                
                using IServiceScope scope = sp.CreateScope();
                
                CinemaAppDbContext dbContext = scope
                    .ServiceProvider
                    .GetRequiredService<CinemaAppDbContext>();
                
                dbContext.Database.EnsureCreated();
            });
        }
    }
}
