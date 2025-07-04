// Services/WorkoutService.cs
using Microsoft.EntityFrameworkCore;
using treadmill_server.Contexts;
using treadmill_server.DTO;
using treadmill_server.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using treadmill_server.DTO;

namespace treadmill_server.Services;

public class WorkoutService
{
    private readonly TreadmillEfCoreContext _context;

    public WorkoutService(TreadmillEfCoreContext context)
    {
        _context = context;
    }
    
    
    public async Task<Workout> StartWorkoutAsync(StartWorkoutDto startDto)
    {
        var workout = new Workout
        {
            UserId = startDto.UserId,
            FitnessMachineId = startDto.FitnessMachineId,
            StartTimeUtc = DateTime.UtcNow,
            // EndTimeUtc, TraveledDistance, CalorieExpenditure залишаються за замовчуванням
        };

        _context.Workouts.Add(workout);
        await _context.SaveChangesAsync();
        return workout;
    }
    
    
    public async Task<Workout?> EndWorkoutAsync(int workoutId, EndWorkoutDto endDto)
    {
        var workout = await _context.Workouts.FindAsync(workoutId);

        if (workout == null || workout.EndTimeUtc.HasValue)
        {
            return null;
        }

        workout.EndTimeUtc = DateTime.UtcNow;
        workout.TraveledDistance = endDto.TraveledDistance;
        workout.CalorieExpenditure = endDto.CalorieExpenditure;

        _context.Workouts.Update(workout);
        await _context.SaveChangesAsync();
        return workout;
    }
    

    public async Task<Workout?> GetWorkoutByIdAsync(int workoutId)
    {
        return await _context.Workouts.FindAsync(workoutId);
    }


    public async Task<IEnumerable<Workout>> GetWorkoutsForUserAsync(int userId)
    {
        return await _context.Workouts
                             .Where(w => w.UserId == userId)
                             .OrderByDescending(w => w.StartTimeUtc)
                             .ToListAsync();
    }
}