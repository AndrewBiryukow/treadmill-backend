using treadmill_server.Entities.Enums;

namespace treadmill_server.DTO;

public record WorkoutDto(int Id, int UserId, int FitnessMachineId, int Distance, int Calories, int Time, DateTime CreatedAt);


public record CreateWorkoutWithDataDto(
    int UserId,
    string DeviceLocalId,
    string FitnessMachineName,
    FitnessMachineType DeviceType,
    int Distance,
    int Calories,
    int Time
);


public record CreateWorkoutDto(
    int UserId,
    string DeviceLocalId,
    int Distance,
    int Calories,
    int Time
);

public record UpdateWorkoutDto(int Distance, int Calories, int Time);