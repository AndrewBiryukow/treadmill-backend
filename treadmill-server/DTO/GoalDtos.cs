using treadmill_server.Entities.Enums;

namespace treadmill_server.DTO;


public record GoalDto(
    int Id, 
    string Title, 
    string Description, 
    string ImagePath, 
    GoalStatus Status, 
    GoalConditionType Condition, 
    double ConditionValue
);


public record CreateGoalDto(
    string Title, 
    string Description, 
    string ImagePath, 
    GoalConditionType Condition, 
    double ConditionValue
);