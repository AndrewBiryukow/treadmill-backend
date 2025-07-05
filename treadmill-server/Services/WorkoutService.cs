using treadmill_server.Data.Abstract;
using treadmill_server.DTO;
using treadmill_server.Entities;

namespace treadmill_server.Services;

public class WorkoutService
{
    private readonly IWorkoutRepository _workoutRepository;

    public WorkoutService(IWorkoutRepository workoutRepository)
    {
        _workoutRepository = workoutRepository;
    }
    
    public async Task<Workout> CreateWorkoutAsync(CreateWorkoutDto dto)
    {
        var workout = new Workout
        {
            UserId = dto.UserId,
            FitnessMachineId = dto.FitnessMachineId,
            CreatedAt = dto.CreatedAt,
            Distance = dto.Distance,
            Calories = dto.Calories,
            Time = dto.Time
        };

        await _workoutRepository.AddAsync(workout);
        return workout;
    }

    public async Task<Workout?> GetWorkoutByIdAsync(int workoutId)
    {
        return await _workoutRepository.GetByIdAsync(workoutId);
    }

    public async Task<IEnumerable<Workout>> GetWorkoutsForUserAsync(int userId)
    {
        return await _workoutRepository.GetByUserIdAsync(userId);
    }
}