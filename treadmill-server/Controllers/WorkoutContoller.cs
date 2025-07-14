using Microsoft.AspNetCore.Mvc;
using treadmill_server.DTO;
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
    public async Task<ActionResult<WorkoutDto>> CreateWorkout([FromBody] CreateWorkoutDto createDto)
    {
        var newWorkout = await _workoutService.CreateWorkoutAsync(createDto);
        if (newWorkout == null)
        {
            return BadRequest("User not found.");
        }
        return CreatedAtAction(nameof(GetWorkoutById), new { id = newWorkout.Id }, newWorkout);
    }


    [HttpPost("with-data")]
    public async Task<ActionResult<WorkoutDto>> CreateWorkoutWithData([FromBody] CreateWorkoutWithDataDto createDto)
    {
        var newWorkout = await _workoutService.CreateWorkoutWithDataAsync(createDto);
        if (newWorkout == null)
        {
            return BadRequest("User not found.");
        }
        return CreatedAtAction(nameof(GetWorkoutById), new { id = newWorkout.Id }, newWorkout);
    }
    

    [HttpGet("{id}")]
    public async Task<ActionResult<WorkoutDto>> GetWorkoutById(int id)
    {
        var workout = await _workoutService.GetWorkoutByIdAsync(id); 
        return workout == null ? NotFound() : Ok(workout);
    }


    [HttpGet("user/{userId}")]
    public async Task<ActionResult<IEnumerable<WorkoutDto>>> GetUserWorkouts(int userId)
    {
        var workouts = await _workoutService.GetWorkoutsForUserAsync(userId);
        return Ok(workouts);
    }

 
    [HttpPut("{id}")]
    public async Task<ActionResult<WorkoutDto>> UpdateWorkout(int id, [FromBody] UpdateWorkoutDto updateDto)
    {
        var updatedWorkout = await _workoutService.UpdateWorkoutAsync(id, updateDto);
        return updatedWorkout == null ? NotFound() : Ok(updatedWorkout);
    }
    

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteWorkout(int id)
    {
        var success = await _workoutService.DeleteWorkoutAsync(id);
        return !success ? NotFound() : NoContent();
    }
}