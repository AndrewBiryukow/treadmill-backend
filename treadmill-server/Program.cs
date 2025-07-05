using System.Security.AccessControl;
using DotNetEnv;
using Microsoft.EntityFrameworkCore;
using treadmill_server.Contexts;
using treadmill_server.Data.Abstract;
using treadmill_server.Data.Concrete;
using treadmill_server.Services;

Env.Load();
var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetValue<string>("DEFAULT_CONNECTION_STRING");

// TODO Swagger http://localhost:5130/swagger/index.html

// TODO Challenge - Period(StartedAt-EndedAt), ChallengeType(?), SubEntity(Goals - Image,Title,ShortDesc, Status(?)) Condition(), 

//TODO Workout (Workouts in Schema)-(Logs) - StartedAt-EndedAt

// TODO RecommendationController (?)

// TODO AdminPanelController (?)

// https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<FitnessMachineService>();
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<WorkoutService>();
// builder.Services.AddScoped<ChallengeService>();
// builder.Services.AddScoped<GoalService>();

// builder.Services.AddScoped<IChallengeRepository, ChallengeRepository>();
builder.Services.AddScoped<IWorkoutRepository,WorkoutRepository>();
// builder.Services.AddScoped<IGoalRepository, GoalRepository>();
builder.Services.AddScoped<IFitnessMachineRepository, FitnessMachineRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();




builder.Services.AddDbContext<ITreadmillEfCoreContext, TreadmillEfCoreContext>(options =>
    options.UseNpgsql(connectionString)
        .UseSnakeCaseNamingConvention());

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ITreadmillEfCoreContext>();

    if (!dbContext.Database.CanConnect())
    {
        throw new NotImplementedException("Can't connect to database!");
    }
}



if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};



app.MapGet("/weatherforecast", () =>
    {
        var forecast = Enumerable.Range(1, 5).Select(index =>
                new WeatherForecast
                (
                    DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                    Random.Shared.Next(-20, 55),
                    summaries[Random.Shared.Next(summaries.Length)]
                ))
            .ToArray();
        return forecast;
    })
    .WithName("GetWeatherForecast");


record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}

