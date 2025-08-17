using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace etip.Models;

public class Vehicle
{
    public int Id { get; set; }
    [Required]
    public string LicensePlate { get; set; } = string.Empty;
    public bool Type { get; set; }
    
    public ICollection<ParkingSession> ParkingSessions { get; set; } = new List<ParkingSession>();
}