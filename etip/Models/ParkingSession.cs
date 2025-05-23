namespace etip.Models;

public class ParkingSession : BaseModel
{
    public int Id { get; set; }
    public int? VehicleId { get; set; }
    public int? GateInId { get; set; }
    public int? GateOutId { get; set; }
    public DateTime? CheckInTime { get; set; }
    public DateTime? CheckOutTime { get; set; }
    public Guid? EmployeeInId { get; set; }
    public Guid? EmployeeOutId { get; set; }
    public int? ParkingRateId { get; set; }
    public decimal? TotalFee { get; set; }
    public bool? Penalty { get; set; } = false;
    public int? PaymentMethodId { get; set; }

    public virtual Employee EmployeeIn { get; set; }
    public virtual Employee EmployeeOut { get; set; }
    public virtual ParkingRate ParkingRate { get; set; }
    public virtual Vehicle Vehicle { get; set; }
    public virtual Gate GateIn { get; set; }
    public virtual Gate GateOut { get; set; }
    public virtual PaymentMethod PaymentMethod { get; set; }
    
   
}