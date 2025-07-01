using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using treadmill_server.Contexts;
using treadmill_server.Entities;


namespace treadmill_server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FitnessMachinesController : ControllerBase
{
    private readonly TreadmillEfCoreContext _context;

    public FitnessMachinesController(TreadmillEfCoreContext context)
    {
        _context = context;
    }

    // GET: api/fitnessmachines
    [HttpGet]
    public async Task<ActionResult<IEnumerable<FitnessMachine>>> GetFitnessMachines()
    {
        return await _context.FitnessMachines.ToListAsync();
    }
    
    // GET: api/fitnessmachines/byuser/5
    [HttpGet("byuser/{userId}")]
    public async Task<ActionResult<IEnumerable<FitnessMachine>>> GetFitnessMachinesByUser(int userId)
    {
        return await _context.FitnessMachines.Where(fm => fm.UserId == userId).ToListAsync();
    }

    // POST: api/fitnessmachines
    [HttpPost]
    public async Task<ActionResult<FitnessMachine>> PostFitnessMachine(FitnessMachine fitnessMachine)
    {
        var userExists = await _context.Users.AnyAsync(u => u.Id == fitnessMachine.UserId);
        if (!userExists)
        {
            return BadRequest($"User with Id {fitnessMachine.UserId} not found.");
        }
        
        _context.FitnessMachines.Add(fitnessMachine);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetFitnessMachines), new { id = fitnessMachine.Id }, fitnessMachine);
    }
}