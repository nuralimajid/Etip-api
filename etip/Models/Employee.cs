using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace etip.Models;

public class Employee : BaseModel
{
    [Key]
    public Guid Id { get; set; }
    [Required]
    public string Name { get; set; } = string.Empty;
    [Required]
    public string RegistrationNumber { get; set; } = string.Empty;
    public int? PositionId { get; set; }
    public bool Status { get; set; }
    
    public Position? Position { get; set; }
    public ICollection<ParkingSession> TapInSessions { get; set; } = new List<ParkingSession>();
    public ICollection<ParkingSession> TapOutSessions { get; set; } = new List<ParkingSession>();
}