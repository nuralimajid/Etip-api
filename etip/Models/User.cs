using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace etip.Models;

public class User :BaseModel
{
    public Guid Id { get; set; }
    [Required]
    public string Username { get; set; } = string.Empty;
    [Required]
    public string Password { get; set; } = string.Empty;
    public Guid? EmployeeId { get; set; }
    public bool IsActive { get; set; }
    public DateTime? LastLogin { get; set; }
    
    public Employee? Employee { get; set; }
    public ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
}