using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace etip.Models;

public class Role : BaseModel
{
    public int Id { get; set; }
    [Required]
    public string Name { get; set; } = string.Empty;
    
    public ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
}