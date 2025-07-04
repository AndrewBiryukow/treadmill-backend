using Microsoft.EntityFrameworkCore;
using treadmill_server.Entities;

namespace treadmill_server.Contexts;

public class TreadmillEfCoreContext(DbContextOptions<TreadmillEfCoreContext> options) : DbContext(options), ITreadmillEfCoreContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<FitnessMachine> FitnessMachines { get; set; }
    public DbSet<Workout> Workouts { get; set; }
    public DbSet<Challenge> Challenges { get; set; }
    
    public DbSet<Goal> Goals { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<User>()
            .HasMany(u => u.FitnessMachines)
            .WithOne(fm => fm.User)
            .HasForeignKey(fm => fm.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        
        modelBuilder.Entity<User>()
            .HasMany<Workout>() 
            .WithOne()
            .HasForeignKey(w => w.UserId)
            .OnDelete(DeleteBehavior.Cascade);


        modelBuilder.Entity<FitnessMachine>()
            .HasMany<Workout>() 
            .WithOne()
            .HasForeignKey(w => w.FitnessMachineId)
            .OnDelete(DeleteBehavior.SetNull); 


        modelBuilder.Entity<Challenge>()
            .HasOne(c => c.Goal)
            .WithOne() 
            .HasForeignKey<Challenge>(c => c.GoalId)
            .OnDelete(DeleteBehavior.Cascade);
        
        modelBuilder.Entity<User>()
            .HasMany(u => u.Challenges)
            .WithMany(c => c.Users); 
        
        modelBuilder.Entity<FitnessMachine>()
            .HasMany(fm => fm.Challenges)
            .WithMany(c => c.FitnessMachines);
    }
}