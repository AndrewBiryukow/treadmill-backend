// Controllers/ChallengeController.cs
using Microsoft.AspNetCore.Mvc;
using treadmill_server.DTO;
using treadmill_server.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using treadmill_server.DTO;
using treadmill_server.Entities;

namespace treadmill_server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ChallengeController : ControllerBase
{
    private readonly ChallengeService _challengeService;

    public ChallengeController(ChallengeService challengeService)
    {
        _challengeService = challengeService;
    }


    [HttpPost]
    public async Task<IActionResult> CreateChallenge([FromBody] CreateChallengeDto createDto)
    {
        var challenge = await _challengeService.CreateChallengeAsync(createDto);
        return CreatedAtAction(nameof(GetChallenge), new { id = challenge.Id }, challenge);
    }
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Challenge>>> GetChallenges()
    {
        var challenges = await _challengeService.GetAllChallengesAsync();
        return Ok(challenges);
    }


    [HttpGet("{id}")]
    public async Task<IActionResult> GetChallenge(int id)
    {
        var challenge = await _challengeService.GetChallengeByIdAsync(id);
        if (challenge == null)
        {
            return NotFound();
        }
        return Ok(challenge);
    }
}