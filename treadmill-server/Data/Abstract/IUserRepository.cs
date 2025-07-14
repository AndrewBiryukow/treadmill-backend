using System.Linq.Expressions;
using treadmill_server.Entities;

namespace treadmill_server.Data.Abstract;

public interface IUserRepository
{
    Task<User?> GetByIdAsync(int id);
    Task<IEnumerable<User>> GetAllAsync();
    Task<User?> GetByUsernameAsync(string username);
    Task<bool> AnyAsync(Expression<Func<User, bool>> predicate);
    Task AddAsync(User user);
    Task UpdateAsync(User user);
    Task DeleteAsync(int id);
}