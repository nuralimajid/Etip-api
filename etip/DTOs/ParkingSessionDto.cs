namespace etip.DTOs;

public class ParkingSessionDto : IMapFrom<ParkingSession>
{
    public int Id { get; set; }
    public int VehicleId { get; set; }
    public int GateInId { get; set; }
    public int GateOutId { get; set; }
    public DateTime CheckInTime { get; set; }
    public DateTime? CheckOutTime { get; set; }
    public Guid? EmployeeInId { get; set; }
    public Guid? EmployeeOutId { get; set; }
    public int? ParkingRateId { get; set; }
    public decimal? TotalFee { get; set; }
    public bool? Penalty { get; set; } = false;
    public int? PaymentMethodId { get; set; }

    public virtual EmployeeDto EmployeeIn { get; set; }
    public virtual EmployeeDto EmployeeOut { get; set; }
    public virtual ParkingRateDto ParkingRate { get; set; }
    public virtual VehiclesDto Vehicle { get; set; }
    public virtual GateDto GateIn { get; set; }
    public virtual GateDto GateOut { get; set; }
    public virtual PaymentMethodDto PaymentMethod { get; set; }
}