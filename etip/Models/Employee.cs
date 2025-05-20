using System.ComponentModel.DataAnnotations;

namespace etip.Models;

public class Employee : BaseModel
{
    [Key]
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? RegistrationNumber { get; set; }
    public int? PositionId { get; set; }
    public bool? IsUser { get; set; }
    public bool? Status { get; set; }
    
    public Position Position { get; set; }
    public ICollection<ParkingSession> TapInSessions { get; set; }
    public ICollection<ParkingSession> TapOutSessions { get; set; }
}