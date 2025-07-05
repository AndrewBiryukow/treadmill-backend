using Microsoft.AspNetCore.Mvc;
using treadmill_server.DTO;
using treadmill_server.Entities;
using treadmill_server.Services;

namespace treadmill_server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WorkoutController : ControllerBase
{
    private readonly WorkoutService _workoutService;

    public WorkoutController(WorkoutService workoutService)
    {
        _workoutService = workoutService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateWorkout([FromBody] CreateWorkoutDto createDto)
    {
        var newWorkout = await _workoutService.CreateWorkoutAsync(createDto);
        return CreatedAtAction(nameof(GetWorkout), new { id = newWorkout.Id }, newWorkout);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetWorkout(int id)
    {
        var workout = await _workoutService.GetWorkoutByIdAsync(id);
        if (workout == null)
        {
            return NotFound();
        }
        return Ok(workout);
    }

    [HttpGet("user/{userId}")]
    public async Task<ActionResult<IEnumerable<Workout>>> GetUserWorkouts(int userId)
    {
        var workouts = await _workoutService.GetWorkoutsForUserAsync(userId);
        return Ok(workouts);
    }
}