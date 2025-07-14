using System.Linq.Expressions;
using treadmill_server.Entities;

namespace treadmill_server.Data.Abstract;

public interface IFitnessMachineRepository
{
    Task<FitnessMachine?> GetByIdAsync(int id);
    Task<IEnumerable<FitnessMachine>> GetAllAsync();
    Task<IEnumerable<FitnessMachine>> GetByUserIdAsync(int userId);
    Task<FitnessMachine?> FindByDeviceLocalIdAsync(int userId, string deviceLocalId);
    Task<bool> AnyAsync(Expression<Func<FitnessMachine, bool>> predicate);
    Task AddAsync(FitnessMachine machine);
    Task UpdateAsync(FitnessMachine machine);
    Task DeleteAsync(int id);
}