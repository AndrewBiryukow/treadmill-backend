using treadmill_server.Entities.Enums;

namespace treadmill_server.DTO;

public record UserDto(int Id, string Name, string Username, UserStatus Status);


public record CreateUserDto(string Name);

public record UpdateUserDto(string Name, UserStatus Status);