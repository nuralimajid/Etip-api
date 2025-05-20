namespace etip.DTOs;

public class UserDto : IMapFrom<User>
{
    public Guid Id { get; set; }
    [Required] public string Username { get; set; } = String.Empty;
    [Required] public string Password { get; set; } = String.Empty;
    public Guid EmployeeId { get; set; }
    public bool IsActive { get; set; }
    public DateTime LastLogin { get; set; } = DateTime.Now;

    public EmployeeDto Employee { get; set; } = new EmployeeDto();
}