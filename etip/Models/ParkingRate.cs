namespace etip.Models;

public class ParkingRate
{
    public int Id { get; set; }
    public decimal FirstHourRate { get; set; }
    public decimal NextHourRate { get; set; }
    public decimal DailyMaxRate { get; set; }
    public decimal OverDuePinaltyPerDay { get; set; }
    public DateTime EffectiveFrom { get; set; }
}