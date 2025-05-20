namespace etip.DTOs;

public class GateDto : IMapFrom<Gate>
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Location { get; set; } = string.Empty;
    public string? Type { get; set; } = string.Empty;
    public bool Status { get; set; } = true;
    public bool HasAttendance { get; set; } = false;
    public bool InOrOut { get; set; } = false;
}