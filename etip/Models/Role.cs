namespace etip.Models;

public class Role : BaseModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    
    public ICollection<UserRole> UserRoles { get; set; }
}