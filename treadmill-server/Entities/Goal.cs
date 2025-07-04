using treadmill_server.Entities.Enums;

namespace treadmill_server.Entities;

public class Goal
{
    public int Id { get; set; }
    
    public string? Title { get; set; }
    
    public string? ImagePath { get; set; }
    
    public string? Description { get; set; }

    public GoalStatus  Status { get; set; }
    
    public GoalConditionType Condition { get; set; }
    
    public double ConditionValue { get; set; }
}