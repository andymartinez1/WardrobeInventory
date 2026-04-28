using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WardrobeInventory.Data;

namespace WardrobeInventory.IntegrationTests;

public class WardrobeWebApplicationFactory<TProgram> : WebApplicationFactory<TProgram>
    where TProgram : class
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureServices(services =>
        {
            var descriptor = services.SingleOrDefault(d =>
                d.ServiceType == typeof(DbContextOptions<WardrobeDbContext>)
            );

            if (descriptor != null)
            {
                services.Remove(descriptor);
            }

            services.AddDbContext<WardrobeDbContext>(options =>
            {
                options.UseInMemoryDatabase("IntegrationTestDb");
            });
        });

        builder.UseEnvironment("Development");
    }
}
