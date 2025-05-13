namespace etip.Models;

public class User :BaseModel
{
    public Guid Id { get; set; }
    public string? Username { get; set; }
    public string? Password { get; set; }
    public Guid? EmployeeId { get; set; }
    public bool? IsActive { get; set; }
    public DateTime? LastLogin { get; set; }
    
    public Employee Employee { get; set; }
    public ICollection<UserRole> UserRoles { get; set; }
    
}