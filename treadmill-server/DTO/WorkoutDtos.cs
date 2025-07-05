namespace treadmill_server.DTO;

public record WorkoutDto(
    int Id, 
    int UserId, 
    int FitnessMachineId, 
    DateTime CreatedAt, 
    int Time,
    int Distance, 
    int Calories
);

public record CreateWorkoutDto(
    int UserId, 
    int FitnessMachineId, 
    DateTime CreatedAt,
    int Distance, 
    int Calories,
    int Time
);


