using treadmill_server.Entities;

namespace treadmill_server.Data.Abstract;

public interface IGoalRepository
{
    Task<Goal?> GetByIdAsync(int id);
    Task<IEnumerable<Goal>> GetAllAsync();
    Task AddAsync(Goal goal);
    Task UpdateAsync(Goal goal);
    Task DeleteAsync(int id);
    
}