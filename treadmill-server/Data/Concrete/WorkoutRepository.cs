using Microsoft.EntityFrameworkCore;
using treadmill_server.Contexts;
using treadmill_server.Data.Abstract;
using treadmill_server.Entities;

namespace treadmill_server.Data.Concrete;

public class WorkoutRepository : IWorkoutRepository
{
    private readonly TreadmillEfCoreContext _context;

    public WorkoutRepository(TreadmillEfCoreContext context)
    {
        _context = context;
    }

    public async Task<Workout?> GetByIdAsync(int id)
    {
        return await _context.Workouts.FindAsync(id);
    }

    public async Task<IEnumerable<Workout>> GetByUserIdAsync(int userId)
    {
        return await _context.Workouts
            .Where(w => w.UserId == userId)
            .ToListAsync();
    }

    public async Task AddAsync(Workout workout)
    {
        await _context.Workouts.AddAsync(workout);
        await _context.SaveChangesAsync();
    }
}