using Microsoft.EntityFrameworkCore;
using treadmill_server.Contexts;
using treadmill_server.Data.Abstract;
using treadmill_server.Entities;

namespace treadmill_server.Data.Concrete;

public class FitnessMachineRepository : IFitnessMachineRepository
{
    private readonly TreadmillEfCoreContext _context;

    public FitnessMachineRepository(TreadmillEfCoreContext context)
    {
        _context = context;
    }

    public async Task<FitnessMachine?> GetByIdAsync(int id)
    {
        return await _context.FitnessMachines.FindAsync(id);
    }

    public async Task<IEnumerable<FitnessMachine>> GetAllAsync()
    {
        return await _context.FitnessMachines.ToListAsync();
    }

    public async Task<IEnumerable<FitnessMachine>> GetByUserIdAsync(int userId)
    {
        return await _context.FitnessMachines
            .Where(fm => fm.UserId == userId)
            .ToListAsync();
    }
    
    public async Task AddAsync(FitnessMachine machine)
    {
        await _context.FitnessMachines.AddAsync(machine);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(FitnessMachine machine)
    {
        _context.FitnessMachines.Update(machine);
        await _context.SaveChangesAsync();
    }
    
    public async Task DeleteAsync(int id)
    {
        var machine = await GetByIdAsync(id);
        if (machine != null)
        {
            _context.FitnessMachines.Remove(machine);
            await _context.SaveChangesAsync();
        }
    }
}