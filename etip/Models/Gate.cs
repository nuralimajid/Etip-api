namespace etip.Models;

public class Gate
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Location { get; set; }
    public bool? Type { get; set; }
    public bool? Status { get; set; }
    public bool? HasAttendance { get; set; }
    public bool? InOrOut { get; set; }
    
    public ICollection<ParkingSession> ParkingSessions { get; set; }
    public ICollection<GatePaymentOption> GatePaymentOptions { get; set; }
}