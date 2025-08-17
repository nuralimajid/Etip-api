using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace etip.Models;

public class Gate
{
    public int Id { get; set; }
    [Required]
    public string Name { get; set; } = string.Empty;
    [Required]
    public string Location { get; set; } = string.Empty;
    public bool Type { get; set; }
    public bool Status { get; set; }
    public bool HasAttendance { get; set; }
    public bool InOrOut { get; set; }
    
    public ICollection<ParkingSession> ParkingSessionsIn { get; set; } = new List<ParkingSession>();
    public ICollection<ParkingSession> ParkingSessionsOut { get; set; } = new List<ParkingSession>();
    public ICollection<GatePaymentOption> GatePaymentOptions { get; set; } = new List<GatePaymentOption>();
}