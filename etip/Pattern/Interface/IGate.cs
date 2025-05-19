using etip.Models;

namespace etip.Pattern.Interface;

public interface IGate
{
    Task<IEnumerable<Gate>> GetAllGatesAsync();
    Task<Gate?> GetGateByIdAsync(int id);
    Task AddAsync(Gate entity);
    Task UpdateAsync(Gate entity);
    Task DeleteAsync(int id);
}

