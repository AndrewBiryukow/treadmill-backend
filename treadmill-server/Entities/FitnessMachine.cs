using treadmill_server.Entities.Enums;

namespace treadmill_server.Entities;

public class FitnessMachine
{
    public int Id { get; set; }
    
    public string Name { get; set; }
    

    public int HeartRate { get; set; } = 0;

    public int StepCount { get; set; } = 0;

    public double DistanceTraveled { get; set; } = 0;

    public int CalorieExpenditure { get; set; } = 0;
    
    public FitnessMachineType DeviceType { get; set; }
    
    public int UserId { get; set; }
    
    public User User { get; set; }
    
    public ICollection<Challenge>? Challenges { get; set; }
}