using Microsoft.EntityFrameworkCore;
using treadmill_server.Contexts;
using treadmill_server.Data.Abstract;
using treadmill_server.DTO;
using treadmill_server.Entities;
using treadmill_server.Utils; 
using treadmill_server.Entities.Enums;

namespace treadmill_server.Services;

public class UserService
{
    private readonly Haikunator.Haikunator _haikunator;
    private readonly Random _random;
    private readonly IUserRepository _userRepository;

    
    public UserService(IUserRepository userRepository)
    {
        _haikunator = new Haikunator.Haikunator();
        _random = new Random();
        _userRepository = userRepository;
    }
    
    public async Task<IEnumerable<UserDto>> GetAllUsersAsync()
    {
        var users = await _userRepository.GetAllAsync();
        return users.Select(u => new UserDto(u.Id, u.Name, u.Username, u.Status));
    }

    public async Task<UserDto?> GetUserByIdAsync(int id)
    {
        var user = await _userRepository.GetByIdAsync(id);
        if (user == null) return null;
        return new UserDto(user.Id, user.Name, user.Username, user.Status);
    }

    public async Task<UserDto> CreateUserAsync(CreateUserDto dto)
    {
        var newUser = new User
        {
            Name = dto.Name,
            Username = await GenerateUniqueUsernameAsync(),
            Status = UserStatus.New
        };
        await _userRepository.AddAsync(newUser);
        return new UserDto(newUser.Id, newUser.Name, newUser.Username, newUser.Status);
    }

    public async Task<UserDto?> UpdateUserAsync(int id, UpdateUserDto dto)
    {
        var user = await _userRepository.GetByIdAsync(id);
        if (user == null) return null;

        user.Name = dto.Name;
        user.Status = dto.Status;
        await _userRepository.UpdateAsync(user);

        return new UserDto(user.Id, user.Name, user.Username, user.Status);
    }

    public async Task<bool> DeleteUserAsync(int id)
    {
        var user = await _userRepository.GetByIdAsync(id);
        if (user == null) return false;

        await _userRepository.DeleteAsync(id);
        return true;
    }


    private async Task<string> GenerateUniqueUsernameAsync()
    {
        while (true)
        {

            string baseWords = _haikunator.Haikunate(tokenLength: 0, delimiter: "-");
            string formattedWords = StringUtils.FormatHaikuWords(baseWords);
            int token = _random.Next(1000, 10000);
            string candidateUsername = $"{formattedWords}_{token}";
            

            if (!await _userRepository.AnyAsync(u => u.Username == candidateUsername)){
                return candidateUsername; 
            }
        }
    }
}

