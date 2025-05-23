namespace etip.Models;

public class Vehicle
{
    public int Id { get; set; }
    public string? LicensePlate { get; set; }
    public bool Type { get; set; }
    
    public ICollection<ParkingSession> ParkingSessions { get; set; }
}