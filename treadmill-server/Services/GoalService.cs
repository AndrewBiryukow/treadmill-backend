using treadmill_server.Data.Abstract;
using treadmill_server.DTO;
using treadmill_server.Entities;
using treadmill_server.Entities.Enums;
using System.Collections.Generic;
using System.Threading.Tasks;
using treadmill_server.DTO;

namespace treadmill_server.Services;

public class GoalService
{
    private readonly IGoalRepository _goalRepository;

    public GoalService(IGoalRepository goalRepository)
    {
        _goalRepository = goalRepository;
    }

    public async Task<Goal?> GetGoalByIdAsync(int id)
    {
        return await _goalRepository.GetByIdAsync(id);
    }

    public async Task<IEnumerable<Goal>> GetAllGoalsAsync()
    {
        return await _goalRepository.GetAllAsync();
    }

    public async Task<Goal> CreateGoalAsync(CreateGoalDto goalDto)
    {
        var newGoal = new Goal
        {
            Title = goalDto.Title,
            Description = goalDto.Description,
            ImagePath = goalDto.ImagePath,
            Condition = goalDto.Condition,
            ConditionValue = goalDto.ConditionValue,
            Status = GoalStatus.Active // Статус за замовчуванням
        };

        await _goalRepository.AddAsync(newGoal);
        return newGoal;
    }
}