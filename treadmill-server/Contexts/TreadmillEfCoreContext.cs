using Microsoft.EntityFrameworkCore;
using treadmill_server.Entities;
using treadmill_server.Entities.Enums;

namespace treadmill_server.Contexts;

public class TreadmillEfCoreContext(DbContextOptions<TreadmillEfCoreContext> options) : DbContext(options), ITreadmillEfCoreContext
{
     public DbSet<User> Users { get; set; }
     public DbSet<FitnessMachine> FitnessMachines { get; set; }
     public DbSet<Workout> Workouts { get; set; }
   // public DbSet<Challenge> Challenges { get; set; }
    
   // public DbSet<Goal> Goals { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // modelBuilder.Entity<User>();
        //     .HasMany<FitnessMachine>();
        // .WithOne(fm => fm.User)
        // .HasForeignKey(fm => fm.UserId)
        // .OnDelete(DeleteBehavior.Cascade);


        // modelBuilder.Entity<User>()
        //     .HasMany<Workout>();
        //  .WithOne()
        // .HasForeignKey(w => w.UserId);
        //   .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<User>()
            .Property(u => u.Status)
            .HasDefaultValue(UserStatus.New);
        
        modelBuilder.Entity<Workout>()
            .Property(w => w.CreatedAt)
            .HasDefaultValueSql("CURRENT_TIMESTAMP");

            modelBuilder.Entity<User>()
                .HasMany(u => u.Workouts) 
                .WithOne()            
                .HasForeignKey(w => w.UserId); 
      
            
            modelBuilder.Entity<FitnessMachine>()
                .HasMany(ft => ft.Workouts) 
                .WithOne()            
                .HasForeignKey(w => w.FitnessMachineId); 
            /*modelBuilder.Entity<FitnessMachine>()
                .HasMany(ft => ft.) 
                .WithOne()               
                .HasForeignKey(w => w.UserId); */
        
            
       
        // modelBuilder.Entity<Challenge>()
        //     .HasOne(c => c.Goal)
        //     .WithOne() 
        //     .HasForeignKey<Challenge>(c => c.GoalId)
        //     .OnDelete(DeleteBehavior.Cascade);

        // modelBuilder.Entity<User>()
        //     .HasMany(u => u.Challenges)
        //     .WithMany(c => c.Users); 

    }
}