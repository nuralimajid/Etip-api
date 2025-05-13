namespace etip.Models;

public class Employee : BaseModel
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Registration_Number { get; set; }
    public int? Position_Id { get; set; }
    public bool? Is_User { get; set; }
    public int? Status { get; set; }
    
    public Position Position { get; set; }
    public ICollection<ParkingSession> TapInSessions { get; set; }
    public ICollection<ParkingSession> TapOutSessions { get; set; }
}