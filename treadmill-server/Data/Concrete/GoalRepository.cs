// using Microsoft.EntityFrameworkCore;
// using treadmill_server.Contexts;
// using treadmill_server.Data.Abstract;
// using treadmill_server.Entities;
//
// namespace treadmill_server.Data.Concrete;
//
// public class GoalRepository : IGoalRepository
// {
//     private readonly TreadmillEfCoreContext _context;
//
//     public GoalRepository(TreadmillEfCoreContext context)
//     {
//         _context = context;
//     }
//
//     public async Task<Goal?> GetByIdAsync(int id) 
//     {
//         return await _context.Goals.FindAsync(id);
//     }
//
//     public async Task<IEnumerable<Goal>> GetAllAsync()
//     {
//         return await _context.Goals.ToListAsync();
//     }
//
//     public async Task AddAsync(Goal goal)
//     {
//         await _context.Goals.AddAsync(goal);
//         await _context.SaveChangesAsync();
//     }
//
//     public async Task UpdateAsync(Goal goal)
//     {
//         _context.Goals.Update(goal);
//         await _context.SaveChangesAsync();
//     }
//
//     public async Task DeleteAsync(int id)
//     {
//         var goal = await GetByIdAsync(id);
//         if (goal != null)
//         {
//             _context.Goals.Remove(goal);
//             await _context.SaveChangesAsync();
//         }
//     }
// }