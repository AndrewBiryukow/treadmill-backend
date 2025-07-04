
using Microsoft.AspNetCore.Mvc;
using treadmill_server.DTO;
using treadmill_server.Services;
using System.Threading.Tasks;
using System.Collections.Generic;
using treadmill_server.DTO;
using treadmill_server.Entities;

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


    [HttpPost("start")]
    public async Task<IActionResult> StartWorkout([FromBody] StartWorkoutDto startDto)
    {
        var newWorkout = await _workoutService.StartWorkoutAsync(startDto);
        return Ok(newWorkout);
    }


    [HttpPost("{id}/end")]
    public async Task<IActionResult> EndWorkout(int id, [FromBody] EndWorkoutDto endDto)
    {
        var endedWorkout = await _workoutService.EndWorkoutAsync(id, endDto);
        if (endedWorkout == null)
        {
            return NotFound("Workout not found or already completed.");
        }
        return Ok(endedWorkout);
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