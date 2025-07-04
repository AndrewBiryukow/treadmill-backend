using treadmill_server.Entities;

namespace treadmill_server.Data.Abstract;

public interface IChallengeRepository
{
    Task<Challenge?> GetByIdAsync(int id);
    Task<IEnumerable<Challenge>> GetAllAsync();
    Task AddAsync(Challenge challenge);
    Task UpdateAsync(Challenge challenge);
    Task DeleteAsync(int id);
}