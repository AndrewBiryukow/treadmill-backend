namespace treadmill_server.DTO;

using System;


public record StartWorkoutDto(int UserId, int FitnessMachineId);


public record EndWorkoutDto(int TraveledDistance, int CalorieExpenditure);

public record WorkoutDto(
    int Id,
    int UserId,
    int FitnessMachineId,
    DateTime StartTimeUtc,
    DateTime? EndTimeUtc,
    int TraveledDistance,
    int CalorieExpenditure
);