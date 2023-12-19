using Microsoft.EntityFrameworkCore;

namespace SmileKitty.EntityFrameworkCore;

public class SmileKittyDbContext(DbContextOptions<SmileKittyDbContext> options)
    : DbContext(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        return base.SaveChangesAsync(cancellationToken);
    }
}