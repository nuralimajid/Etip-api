namespace etip.DTOs;

public class PositionDto : IMapFrom<Position>
{
    public int Id { get; set; }
    public string Name { get; set; } = String.Empty;
    public string? Description { get; set; }
}