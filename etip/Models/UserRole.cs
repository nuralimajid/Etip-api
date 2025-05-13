namespace etip.Models;

public class UserRole : BaseModel
{
    public Guid UserId { get; set; }
    public int RoleId { get; set; }
    
    public User User { get; set; }
    public Role Role { get; set; }
}