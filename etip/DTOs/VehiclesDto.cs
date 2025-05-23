namespace etip.DTOs;

public class VehiclesDto : IMapFrom<Vehicle>
{
    public int Id { get; set; }
    public string LicensePlate { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
    public bool Status { get; set; }
}