namespace etip.DTOs;

public class StatusUserDto : IMapFrom<StatusUser>
{
    public int Id { get; set; }
    public string Name { get; set; } = String.Empty;
}