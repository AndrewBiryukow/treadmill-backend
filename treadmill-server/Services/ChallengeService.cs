using treadmill_server.Data.Abstract;
using treadmill_server.DTO;
using treadmill_server.Entities;
using treadmill_server.Entities.Enums;

namespace treadmill_server.Services;

public class ChallengeService
{
    private readonly IChallengeRepository _challengeRepository;

    public ChallengeService(IChallengeRepository challengeRepository)
    {
        _challengeRepository = challengeRepository;
    }

    public async Task<Challenge?> GetChallengeByIdAsync(int id)
    {
        return await _challengeRepository.GetByIdAsync(id);
    }

    public async Task<IEnumerable<Challenge>> GetAllChallengesAsync()
    {
        return await _challengeRepository.GetAllAsync();
    }

    public async Task<Challenge> CreateChallengeAsync(CreateChallengeDto dto)
    {

        var newGoal = new Goal
        {
            Title = dto.Goal.Title,
            Description = dto.Goal.Description,
            ImagePath = dto.Goal.ImagePath,
            Condition = dto.Goal.Condition,
            ConditionValue = dto.Goal.ConditionValue,
            Status = GoalStatus.Active 
        };


        var newChallenge = new Challenge
        {
            Title = dto.Title,
            ChallengeType = dto.ChallengeType,
            Goal = newGoal,
            StartTimeUtc = DateTime.UtcNow
        };


        await _challengeRepository.AddAsync(newChallenge);

        return newChallenge;
    }
}