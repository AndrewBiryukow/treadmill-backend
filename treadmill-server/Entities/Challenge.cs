namespace treadmill_server.Entities;

public class Challenge
{
    public int Id { get; set; }
    
    public string Title { get; set; }
    
    public string ChallengeType { get; set; }
    
    public Goal Goal { get; set; } 
    
    public int GoalId { get; set; }
    
    public DateTime StartTimeUtc { get; set; }
    
    public DateTime? EndTimeUtc { get; set; }
    
    public ICollection<User> Users { get; set; }
    
    public ICollection<FitnessMachine> FitnessMachines { get; set; }
}