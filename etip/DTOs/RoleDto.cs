namespace etip.DTOs;

public class RoleDto : IMapFrom<Role>
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Name is required")]
    public string Name { get; set; } = String.Empty;
}