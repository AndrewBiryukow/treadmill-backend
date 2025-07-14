using Microsoft.AspNetCore.Mvc;
using treadmill_server.DTO;
using treadmill_server.Services;

namespace treadmill_server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FitnessMachinesController : ControllerBase
{
    private readonly FitnessMachineService _fitnessMachineService;

    public FitnessMachinesController(FitnessMachineService fitnessMachineService)
    {
        _fitnessMachineService = fitnessMachineService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<FitnessMachineDto>>> GetFitnessMachines()
    {
        var machines = await _fitnessMachineService.GetAllAsync();
        return Ok(machines);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<FitnessMachineDto>> GetFitnessMachineById(int id)
    {
        var machine = await _fitnessMachineService.GetByIdAsync(id);
        return machine == null ? NotFound() : Ok(machine);
    }
    
    [HttpGet("user/{userId}")]
    public async Task<ActionResult<IEnumerable<FitnessMachineDto>>> GetFitnessMachinesByUser(int userId)
    {
        var machines = await _fitnessMachineService.GetByUserIdAsync(userId);
        return Ok(machines);
    }

    [HttpPost]
    public async Task<ActionResult<FitnessMachineDto>> CreateFitnessMachine([FromBody] CreateFitnessMachineDto createDto)
    {
        var newMachineDto = await _fitnessMachineService.CreateAsync(createDto);
        if (newMachineDto == null)
        {
            return BadRequest("User not found or device with this local ID already exists for this user.");
        }
        
        return CreatedAtAction(nameof(GetFitnessMachineById), new { id = newMachineDto.Id }, newMachineDto);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<FitnessMachineDto>> UpdateFitnessMachine(int id, [FromBody] UpdateFitnessMachineDto updateDto)
    {
        var updatedMachine = await _fitnessMachineService.UpdateAsync(id, updateDto);
        return updatedMachine == null ? NotFound() : Ok(updatedMachine);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteFitnessMachine(int id)
    {
        var success = await _fitnessMachineService.DeleteAsync(id);
        return !success ? NotFound() : NoContent();
    }
}