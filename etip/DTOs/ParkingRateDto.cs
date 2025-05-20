namespace etip.DTOs;

public class ParkingRateDto : IMapFrom<ParkingRate>
{
    public int Id { get; set; }
    public decimal FirstHourRate { get; set; }
    public decimal NextHourRate { get; set; }
    public decimal DailyMaxRate { get; set; }
    public decimal OverDuePenaltyPerDay { get; set; }
    public DateTime EffectiveFrom { get; set; }
}