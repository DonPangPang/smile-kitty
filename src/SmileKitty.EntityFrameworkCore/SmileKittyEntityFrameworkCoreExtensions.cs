using Microsoft.Extensions.DependencyInjection;
using SmileKitty.EntityFrameworkCore.UnitOfWorks;

namespace SmileKitty.EntityFrameworkCore;

public static class SmileKittyEntityFrameworkCoreExtensions
{
    public static void AddEntityFrameworkCore(this IServiceCollection services)
    {
        services.AddScoped(typeof(IUnitOfWork<>), typeof(UnitOfWork<>));
    }
}