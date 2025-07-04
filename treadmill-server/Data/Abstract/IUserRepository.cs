using treadmill_server.Entities;

namespace treadmill_server.Data.Abstract;

public interface IUserRepository
{
    Task<User?> GetByIdAsync(int id);
    Task<IEnumerable<User>> GetAllAsync();
    Task AddAsync(User user);
    Task UpdateAsync(User user);
    Task DeleteAsync(int id);
    Task<User?> GetByUsernameAsync(string username);
}