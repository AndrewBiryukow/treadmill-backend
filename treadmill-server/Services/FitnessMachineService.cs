using Microsoft.EntityFrameworkCore;
using treadmill_server.Data.Abstract;
using treadmill_server.DTO;
using treadmill_server.Entities;

namespace treadmill_server.Services;

public class FitnessMachineService
{
    private readonly IFitnessMachineRepository _machineRepository;
    private readonly IUserRepository _userRepository;

    public FitnessMachineService(IFitnessMachineRepository machineRepository, IUserRepository userRepository)
    {
        _machineRepository = machineRepository;
        _userRepository = userRepository;
    }


    public async Task<IEnumerable<FitnessMachineDto>> GetAllAsync()
    {
        var machines = await _machineRepository.GetAllAsync();
        
        return machines.Select(m => new FitnessMachineDto(m.Id, m.Name, m.DeviceType, m.UserId));
    }


    public async Task<IEnumerable<FitnessMachineDto>> GetByUserIdAsync(int userId)
    {
        var machines = await _machineRepository.GetByUserIdAsync(userId);
        return machines.Select(m => new FitnessMachineDto(m.Id, m.Name, m.DeviceType, m.UserId));
    }
    
    public async Task<FitnessMachineDto?> CreateAsync(CreateFitnessMachineDto dto)
    {
        var userExists = await _userRepository.GetByIdAsync(dto.UserId);
        if (userExists == null)
        {
            return null;
        }

        var newMachine = new FitnessMachine
        {
            Name = dto.Name,
            DeviceType = dto.DeviceType,
            UserId = dto.UserId,
            DeviceLocalId = dto.DeviceLocalId
        };

        await _machineRepository.AddAsync(newMachine);
        
        return new FitnessMachineDto(newMachine.Id, newMachine.Name, newMachine.DeviceType, newMachine.UserId);
    }
}