using Microsoft.EntityFrameworkCore;
using treadmill_server.Contexts;
using treadmill_server.Data.Abstract;
using treadmill_server.Entities;

namespace treadmill_server.Data.Concrete;

public class ChallengeRepository : IChallengeRepository
{
    private readonly TreadmillEfCoreContext _context;

    public ChallengeRepository(TreadmillEfCoreContext context)
    {
        _context = context;
    }

    public async Task<Challenge?> GetByIdAsync(int id)
    {
        return await _context.Challenges
            .Include(c => c.Goal)
            .FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<IEnumerable<Challenge>> GetAllAsync()
    {
        return await _context.Challenges
            .Include(c => c.Goal)
            .ToListAsync();
    }

    public async Task AddAsync(Challenge challenge)
    {
        await _context.Challenges.AddAsync(challenge);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Challenge challenge)
    {
        _context.Challenges.Update(challenge);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var challenge = await GetByIdAsync(id);
        if (challenge != null)
        {
            _context.Challenges.Remove(challenge);
            await _context.SaveChangesAsync();
        }
    }
}