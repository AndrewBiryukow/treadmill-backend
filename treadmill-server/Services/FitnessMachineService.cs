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
        return machines.Select(m => new FitnessMachineDto(m.Id, m.Name, m.DeviceLocalId, m.DeviceType, m.UserId));
    }

    public async Task<FitnessMachineDto?> GetByIdAsync(int id)
    {
        var machine = await _machineRepository.GetByIdAsync(id);
        if (machine == null) return null;
        return new FitnessMachineDto(machine.Id, machine.Name, machine.DeviceLocalId, machine.DeviceType, machine.UserId);
    }
    
    public async Task<IEnumerable<FitnessMachineDto>> GetByUserIdAsync(int userId)
    {
        var machines = await _machineRepository.GetByUserIdAsync(userId);
        return machines.Select(m => new FitnessMachineDto(m.Id, m.Name, m.DeviceLocalId, m.DeviceType, m.UserId));
    }
    
    public async Task<FitnessMachineDto?> CreateAsync(CreateFitnessMachineDto dto)
    {
        if (!await _userRepository.AnyAsync(u => u.Id == dto.UserId)) return null;
        if (await _machineRepository.AnyAsync(m => m.UserId == dto.UserId && m.DeviceLocalId == dto.DeviceLocalId)) return null;

        var newMachine = new FitnessMachine
        {
            Name = dto.Name,
            DeviceType = dto.DeviceType,
            UserId = dto.UserId,
            DeviceLocalId = dto.DeviceLocalId,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };

        await _machineRepository.AddAsync(newMachine);
        return new FitnessMachineDto(newMachine.Id, newMachine.Name, newMachine.DeviceLocalId, newMachine.DeviceType, newMachine.UserId);
    }
    
    public async Task<FitnessMachineDto?> UpdateAsync(int id, UpdateFitnessMachineDto dto)
    {
        var machine = await _machineRepository.GetByIdAsync(id);
        if (machine == null) return null;

        machine.Name = dto.Name;
        machine.DeviceType = dto.DeviceType;
        machine.UpdatedAt = DateTime.UtcNow;
        await _machineRepository.UpdateAsync(machine);

        return new FitnessMachineDto(machine.Id, machine.Name, machine.DeviceLocalId, machine.DeviceType, machine.UserId);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        if (!await _machineRepository.AnyAsync(m => m.Id == id)) return false;
        
        await _machineRepository.DeleteAsync(id);
        return true;
    }
}