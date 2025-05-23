
namespace etip.Pattern.Interface;

public interface IGate
{
    Task<IEnumerable<GateDto>> GetAllGatesAsync();
    Task<GateDto?> GetGateByIdAsync(int id);
    Task<GateDto> AddAsync(GateDto entity);
    Task<GateDto> UpdateAsync(int id, GateDto entity);
    Task<bool> DeleteAsync(int id);
}

