namespace etip.Models;

public class ParkingSession
{
    public int Id { get; set; }
    public string PlateNumber { get; set; }
    public DateTime TapInTime { get; set; }
    public DateTime? TapOutTime { get; set; }
    public decimal? FinalFee { get; set; }
    
    public int InTapOperatorId { get; set; }
    public int OutTapOperatorId { get; set; }
    
    public Employee InTapEmployee { get; set; }
    public Employee OutTapEmployee { get; set; }
}