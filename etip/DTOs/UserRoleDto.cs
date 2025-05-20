namespace etip.DTOs;

public class UserRoleDto : IMapFrom<UserRole>
{
    public Guid UserId { get; set; }
    public int RoleId { get; set; }

    public UserDto User { get; set; }
    public RoleDto Role { get; set; }
}