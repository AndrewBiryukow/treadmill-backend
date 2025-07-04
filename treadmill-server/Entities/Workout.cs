namespace treadmill_server.Entities;

public class Workout
{
    public int Id { get; set; }
    
    public int UserId { get; set; }
    
    public int FitnessMachineId { get; set; }
    
    public int TraveledDistance { get; set; }
    
    public int CalorieExpenditure { get; set; } 
    
    public DateTime StartTimeUtc { get; set; }
    
    public DateTime? EndTimeUtc { get; set; }
}