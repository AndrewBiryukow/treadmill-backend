using Microsoft.AspNetCore.Mvc;
using treadmill_server.Entities;
using treadmill_server.Services;
using treadmill_server.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace treadmill_server.Controllers;

public record CreateUserDto(string Name);


[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly UserService _userService;
    
    public UsersController(UserService userService)
    {
        _userService = userService;
    }

    // GET: api/users
    [HttpGet]
    public async Task<ActionResult<IEnumerable<User>>> GetUsers()
    {
        var users = await _userService.GetAllUsersAsync();
        return Ok(users);
    }

    // GET: api/users/5
    [HttpGet("{id}")]
    public async Task<ActionResult<User>> GetUser(int id)
    {
        var user = await _userService.GetUserByIdAsync(id);
        if (user == null)
        {
            return NotFound();
        }
        return Ok(user);
    }

    // POST: api/users
    [HttpPost]
    public async Task<ActionResult<User>> CreateUser(CreateUserDto createUserDto)
    {
        var newUser = await _userService.CreateUserAsync(createUserDto.Name);

        return CreatedAtAction(nameof(GetUser), new { id = newUser.Id }, newUser);
    }

    // PUT: api/users/5
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateUser(int id, User userToUpdate)
    {
        if (id != userToUpdate.Id)
        {
            return BadRequest();
        }

        var updatedUser = await _userService.UpdateUserAsync(userToUpdate);
        if (updatedUser == null)
        {
            return NotFound();
        }
        
        return NoContent();
    }
}