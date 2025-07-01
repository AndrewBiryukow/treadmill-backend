using Microsoft.EntityFrameworkCore;
using treadmill_server.Entities;

namespace treadmill_server.Contexts;

public class TreadmillEfCoreContext : DbContext, ITreadmillEfCoreContext
{
    public TreadmillEfCoreContext(DbContextOptions<TreadmillEfCoreContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }
    public DbSet<FitnessMachine> FitnessMachines { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<User>()
            .HasMany(u => u.FitnessMachines)
            .WithOne(fm => fm.User)
            .HasForeignKey(fm => fm.UserId);
    }
}