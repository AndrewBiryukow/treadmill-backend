
using treadmill_server.Entities.Enums;
using treadmill_server.Services;

namespace treadmill_server.Entities;

public class User
{
    public int Id { get; set; }
    
    public static UserService UserService { get; set; }
    
    public string Name { get; set; }

    public string Username { get; set; }

    public UserStatus Status { get; set; }

    public ICollection<FitnessMachine>? FitnessMachines { get; set; }
    
    public ICollection<Workout> Workouts { get; set; }
    
   // public ICollection<Challenge>? Challenges { get; set; }
}