using treadmill_server.Entities.Enums;

namespace treadmill_server.Entities;

public class FitnessMachine
{
    public int Id { get; set; }
    
    public string Name { get; set; }
    
    public string Status { get; set; }
    
    public int HeartRate { get; set; }
    
    public int StepCount { get; set; }
    
    public double DistanceTraveled { get; set; }
    
    public int CalorieExpenditure { get; set; }
    
    public FitnessMachineType DeviceType { get; set; }
    
    public int UserId { get; set; }
    
    public User User { get; set; }
}