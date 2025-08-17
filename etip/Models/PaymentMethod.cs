using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace etip.Models;

public class PaymentMethod : BaseModel
{
    public int Id { get; set; }
    [Required]
    public string Name { get; set; } = string.Empty;
    [Required]
    public string Type { get; set; } = string.Empty;
    public bool IsActive { get; set; }
    
    public ICollection<ParkingSession> ParkingSessions { get; set; } = new List<ParkingSession>();
    public ICollection<GatePaymentOption> GatePaymentOptions { get; set; } = new List<GatePaymentOption>();
}