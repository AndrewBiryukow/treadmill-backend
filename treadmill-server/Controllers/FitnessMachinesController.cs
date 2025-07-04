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


    [HttpGet("byuser/{userId}")]
    public async Task<ActionResult<IEnumerable<FitnessMachineDto>>> GetFitnessMachinesByUser(int userId)
    {
        var machines = await _fitnessMachineService.GetByUserIdAsync(userId);
        return Ok(machines);
    }


    [HttpPost]
    public async Task<ActionResult<FitnessMachineDto>> CreateFitnessMachine(CreateFitnessMachineDto createDto)
    {
        var newMachineDto = await _fitnessMachineService.CreateAsync(createDto);

        if (newMachineDto == null)
        {
            return BadRequest($"User with Id {createDto.UserId} not found.");
        }
        
        return CreatedAtAction(nameof(GetFitnessMachines), new { id = newMachineDto.Id }, newMachineDto);
    }
}