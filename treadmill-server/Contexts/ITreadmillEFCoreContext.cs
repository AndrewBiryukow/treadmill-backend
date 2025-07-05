using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using treadmill_server.Entities;

namespace treadmill_server.Contexts;

public interface ITreadmillEfCoreContext
{
    DbSet<User> Users { get; set; }
    DbSet<FitnessMachine> FitnessMachines { get; set; }
    DbSet<Workout> Workouts { get; set; }
    // DbSet<Challenge> Challenges { get; set; }
    //
    // DbSet<Goal> Goals { get; set; }
    
    DatabaseFacade Database { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}