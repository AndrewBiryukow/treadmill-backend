using treadmill_server.Entities.Enums;

namespace treadmill_server.DTO;


public record FitnessMachineDto(int Id, string Name, string DeviceLocalId, FitnessMachineType DeviceType, int UserId);

public record CreateFitnessMachineDto(string Name, string DeviceLocalId, FitnessMachineType DeviceType, int UserId);

public record UpdateFitnessMachineDto(string Name, FitnessMachineType DeviceType);