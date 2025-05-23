namespace etip.Pattern.Interface;

public interface IVehicles
{
    Task<IEnumerable<VehiclesDto>> GetAllVehiclesAsync();
    Task<VehiclesDto?> GetVehicleByIdAsync(int id);
    Task<VehiclesDto> AddAsync(VehiclesDto entity);
    Task<VehiclesDto> UpdateAsync(int id, VehiclesDto entity);
    Task<bool> DeleteAsync(int id);
}