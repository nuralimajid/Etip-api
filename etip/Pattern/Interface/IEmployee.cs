namespace etip.Pattern.Interface;

public interface IEmployee
{
    Task<IEnumerable<EmployeeDto>> GetAllEmployeesAsync();
    Task<EmployeeDto?> GetEmployeeByIdAsync(Guid id);
    Task<EmployeeDto> AddAsync(EmployeeDto entity);
    Task<EmployeeDto> UpdateAsync(Guid id, EmployeeDto entity);
    Task<bool> DeleteAsync(Guid id);
}