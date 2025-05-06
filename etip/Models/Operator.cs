namespace etip.Models;

public class Operator
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Code { get; set; }
    public string Gate { get; set; }
    
    public ICollection<ParkingSession> TapInSessions { get; set; }
    public ICollection<ParkingSession> TapOutSessions { get; set; }
}