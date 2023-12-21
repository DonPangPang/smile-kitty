using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SmileKitty.EntityFrameworkCore.UnitOfWorks;

namespace SmileKitty.EntityFrameworkCore;

public static class SmileKittyEntityFrameworkCoreExtensions
{
    public static void AddEntityFrameworkCore(this IServiceCollection services)
    {
        services.AddScoped(typeof(IUnitOfWork<>), typeof(UnitOfWork<>));
        services.AddDbContext<SmileKittyDbContext>(setup =>
        {
            setup.UseSqlite("Data Source=smilekitty.db");
        });
    }

    public static async Task InitDatabaseAsync(this IHost app, bool reset = false)
    {
        using var scoped = app.Services.CreateScope();
        await using var dbContext = scoped.ServiceProvider.GetRequiredService<SmileKittyDbContext>();
        try
        {
            if (reset) await dbContext.Database.EnsureDeletedAsync();

            await dbContext.Database.EnsureCreatedAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }
    }
}