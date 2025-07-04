using treadmill_server.Entities.Enums;

namespace treadmill_server.DTO;


public record FitnessMachineDto(int Id, string Name, FitnessMachineType DeviceType, int UserId);

public record CreateFitnessMachineDto(string Name, FitnessMachineType DeviceType, int UserId);