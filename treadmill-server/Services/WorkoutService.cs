using treadmill_server.Data.Abstract;
using treadmill_server.DTO;
using treadmill_server.Entities;
using treadmill_server.Entities.Enums;

namespace treadmill_server.Services;

public class WorkoutService
{
    private readonly IWorkoutRepository _workoutRepository;
    private readonly IFitnessMachineRepository _machineRepository;
    private readonly IUserRepository _userRepository;

    public WorkoutService(IWorkoutRepository workoutRepository, IFitnessMachineRepository machineRepository, IUserRepository userRepository)
    {
        _workoutRepository = workoutRepository;
        _machineRepository = machineRepository;
        _userRepository = userRepository;
    }
    
    public async Task<WorkoutDto?> CreateWorkoutWithDataAsync(CreateWorkoutWithDataDto dto)
    {
        if (!await _userRepository.AnyAsync(u => u.Id == dto.UserId)) return null;

        var machine = await FindOrCreateMachineAsync(dto.UserId, dto.DeviceLocalId, dto.FitnessMachineName, dto.DeviceType);
        var workout = await CreateFinalWorkoutAsync(dto.UserId, machine.Id, dto.Distance, dto.Calories, dto.Time);
        
        return ToWorkoutDto(workout);
    }

 
    public async Task<WorkoutDto?> CreateWorkoutAsync(CreateWorkoutDto dto)
    {
        if (!await _userRepository.AnyAsync(u => u.Id == dto.UserId)) return null;

        var machine = await FindOrCreateMachineAsync(dto.UserId, dto.DeviceLocalId);
        var workout = await CreateFinalWorkoutAsync(dto.UserId, machine.Id, dto.Distance, dto.Calories, dto.Time);

        return ToWorkoutDto(workout);
    }

    public async Task<WorkoutDto?> GetWorkoutByIdAsync(int workoutId)
    {
        var workout = await _workoutRepository.GetByIdAsync(workoutId);
        return workout == null ? null : ToWorkoutDto(workout);
    }

    public async Task<IEnumerable<WorkoutDto>> GetWorkoutsForUserAsync(int userId)
    {
        var workouts = await _workoutRepository.GetByUserIdAsync(userId);
        return workouts.Select(ToWorkoutDto);
    }

    public async Task<WorkoutDto?> UpdateWorkoutAsync(int workoutId, UpdateWorkoutDto dto)
    {
        var workout = await _workoutRepository.GetByIdAsync(workoutId);
        if (workout == null) return null;

        workout.Distance = dto.Distance;
        workout.Calories = dto.Calories;
        workout.Time = dto.Time;
        
        await _workoutRepository.UpdateAsync(workout);
        return ToWorkoutDto(workout);
    }

    public async Task<bool> DeleteWorkoutAsync(int workoutId)
    {
        if (!await _workoutRepository.AnyAsync(w => w.Id == workoutId)) return false;
        
        await _workoutRepository.DeleteAsync(workoutId);
        return true;
    }
    
    private async Task<FitnessMachine> FindOrCreateMachineAsync(int userId, string deviceLocalId, string? name = null, FitnessMachineType? type = null)
    {
        var machine = await _machineRepository.FindByDeviceLocalIdAsync(userId, deviceLocalId);
        if (machine == null)
        {
            machine = new FitnessMachine
            {
                UserId = userId,
                DeviceLocalId = deviceLocalId,
                Name = name ?? $"Device ({deviceLocalId})",
                DeviceType = type ?? FitnessMachineType.Unknown,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };
            await _machineRepository.AddAsync(machine);
        }
        return machine;
    }
    
    private async Task<Workout> CreateFinalWorkoutAsync(int userId, int machineId, int distance, int calories, int time)
    {
        var workout = new Workout
        {
            UserId = userId,
            FitnessMachineId = machineId,
            Distance = distance,
            Calories = calories,
            Time = time,
            CreatedAt = DateTime.UtcNow
        };
        await _workoutRepository.AddAsync(workout);
        return workout;
    }
    
    private static WorkoutDto ToWorkoutDto(Workout workout)
    {
        return new WorkoutDto(workout.Id, workout.UserId, workout.FitnessMachineId, workout.Distance, workout.Calories, workout.Time, workout.CreatedAt);
    }
}