using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace etip.Models;

public class Position : BaseModel
{
    public int Id { get; set; }
    [Required]
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    
    public ICollection<Employee> Employees { get; set; } = new List<Employee>();
}