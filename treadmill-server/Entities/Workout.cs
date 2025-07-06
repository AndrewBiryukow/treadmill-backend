namespace treadmill_server.Entities;

public class Workout
{
    public int Id { get; set; }
    
    public int UserId { get; set; }
    
    public int FitnessMachineId { get; set; }

    public int Distance { get; set; }
    
    public int Calories { get; set; }
    
    public int Time { get; set; }
    
    public DateTime CreatedAt { get; set; }
    
}