namespace treadmill_server.DTO;

public record ChallengeDto(
    int Id,
    string Title,
    string ChallengeType,
    DateTime StartTimeUtc,
    DateTime? EndTimeUtc,
    GoalDto Goal
);


public record CreateChallengeDto(
    string Title,
    string ChallengeType,
    CreateGoalDto Goal
);