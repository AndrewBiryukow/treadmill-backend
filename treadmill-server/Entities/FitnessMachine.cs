using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using treadmill_server.Entities.Enums;

namespace treadmill_server.Entities;

public class FitnessMachine
{
    public int Id { get; set; }
    public int UserId { get; set; }
    [MaxLength(256)]
    public required string DeviceLocalId { get; set; }
    
    [MaxLength(64)] 
    public required string Name { get; set; }
    
    public FitnessMachineType DeviceType { get; set; }
    
   // public User User { get; set; }
    
    public DateTime CreatedAt { get; set; }
    
    public DateTime UpdatedAt { get; set; }
    
    public Collection<Workout> Workouts { get; set; }
    
}