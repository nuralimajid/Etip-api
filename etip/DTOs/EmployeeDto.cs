namespace etip.DTOs;

public class EmployeeDto : IMapFrom<Employee>
{
    public EmployeeDto()
    {
        Id = Guid.NewGuid();
    }

    public Guid Id { get; set; }

    [Required(ErrorMessage = "Name is required")]
    public string Name { get; set; } = String.Empty;

    [Required(ErrorMessage = "Registration number is required")]
    public string RegistrationNumber { get; set; } = String.Empty;

    public int? PositionId { get; set; }
    public bool? Status { get; set; } = true;

    public PositionDto? Position { get; set; }
}