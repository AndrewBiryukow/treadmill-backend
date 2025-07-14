using System.Linq.Expressions;
using treadmill_server.Entities;

namespace treadmill_server.Data.Abstract;

public interface IWorkoutRepository
{
    Task<Workout?> GetByIdAsync(int id);
    Task<IEnumerable<Workout>> GetByUserIdAsync(int userId);
    Task AddAsync(Workout workout);
    Task UpdateAsync(Workout workout);
    Task DeleteAsync(int id);
    
    Task<bool> AnyAsync(Expression<Func<Workout, bool>> predicate);
}