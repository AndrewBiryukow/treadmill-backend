using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using treadmill_server.Contexts;
using treadmill_server.Data.Abstract;
using treadmill_server.Entities;

namespace treadmill_server.Data.Concrete;

public class WorkoutRepository : IWorkoutRepository
{
    private readonly TreadmillEfCoreContext _context;
    public WorkoutRepository(TreadmillEfCoreContext context) { _context = context; }

    public async Task AddAsync(Workout workout)
    {
        await _context.Workouts.AddAsync(workout);
        await _context.SaveChangesAsync();
    }
    public async Task<Workout?> GetByIdAsync(int id) => await _context.Workouts.FindAsync(id);
    public async Task<IEnumerable<Workout>> GetByUserIdAsync(int userId) => await _context.Workouts.Where(w => w.UserId == userId).ToListAsync();
    
    public async Task UpdateAsync(Workout workout)
    {
        _context.Workouts.Update(workout);
        await _context.SaveChangesAsync();
    }
    public async Task DeleteAsync(int id)
    {
        var workout = await GetByIdAsync(id);
        if (workout != null)
        {
            _context.Workouts.Remove(workout);
            await _context.SaveChangesAsync();
        }
    }
    
    public async Task<bool> AnyAsync(Expression<Func<Workout, bool>> predicate)
    {
        return await _context.Workouts.AnyAsync(predicate);
    }
}