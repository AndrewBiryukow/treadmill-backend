namespace treadmill_server.DTO;

public record UserDto(int Id, string Name, string Username, string Status);

public record CreateUserDto(string Name);

public record UpdateUserDto(string Name, string Status);