using Microsoft.EntityFrameworkCore;
using treadmill_server.Contexts;
using treadmill_server.Entities;
using treadmill_server.Utils; 
using treadmill_server.Entities.Enums;

namespace treadmill_server.Services;

public class UserService
{
    private readonly TreadmillEfCoreContext _context;
    private readonly Haikunator.Haikunator _haikunator;
    private readonly Random _random;

    public UserService(TreadmillEfCoreContext context)
    {
        _context = context;
        _haikunator = new Haikunator.Haikunator();
        _random = new Random();
    }
    
    public async Task<User> CreateUserAsync(string name)
    {
        string uniqueUsername = await GenerateUniqueUsernameAsync();

        var newUser = new User
        {
            Name = name,
            Username = uniqueUsername,
            Status = UserStatus.New 
        };

        _context.Users.Add(newUser);
        await _context.SaveChangesAsync();

        return newUser;
    }


    public async Task<IEnumerable<User>> GetAllUsersAsync()
    {
        return await _context.Users
                             .Include(u => u.FitnessMachines) 
                             .ToListAsync();
    }


    public async Task<User?> GetUserByIdAsync(int id)
    {
        return await _context.Users
                             .Include(u => u.FitnessMachines)
                             .FirstOrDefaultAsync(u => u.Id == id);
    }


    public async Task<User?> UpdateUserAsync(User userToUpdate)
    {
        var existingUser = await _context.Users.FindAsync(userToUpdate.Id);
        if (existingUser == null)
        {
            return null;
        }
        
        existingUser.Name = userToUpdate.Name;
        existingUser.Status = userToUpdate.Status;

        _context.Users.Update(existingUser);
        await _context.SaveChangesAsync();

        return existingUser;
    }


    private async Task<string> GenerateUniqueUsernameAsync()
    {
        while (true)
        {

            string baseWords = _haikunator.Haikunate(tokenLength: 0, delimiter: "-");
            string formattedWords = StringUtils.FormatHaikuWords(baseWords);
            int token = _random.Next(1000, 10000);
            string candidateUsername = $"{formattedWords}_{token}";

            bool exists = await _context.Users.AnyAsync(u => u.Username == candidateUsername);

            if (!exists)
            {
                return candidateUsername;
            }
        }
    }
}