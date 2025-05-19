namespace etip.Pattern.Interface;

using etip.Models;
using System;
using System.Collections.Generic;

public interface IEmployee
{
    Task<IEnumerable<Employee>> GetAllEmployeesAsync();
    Task<Employee?> GetEmployeeByIdAsync(Guid id);
    Task AddAsync(Employee entity);
    Task UpdateAsync(Employee entity);
    Task DeleteAsync(Guid id);
}

