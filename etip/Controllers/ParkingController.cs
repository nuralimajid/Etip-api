using etip.Data;
using etip.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace etip.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ParkingController : ControllerBase
{
    private readonly AppDbContext _context;

    public ParkingController(AppDbContext context)
    {
        _context = context;
    }
    
    //Tap In
    [HttpPost("tapin")]
    public async Task<IActionResult> TapIn([FromBody] TapInRequest request)
    {
        var session = new ParkingSession
        {
            PlateNumber = request.PlateNumber,
            TapInTime = DateTime.UtcNow,
            InTapOperatorId = request.OperatorId
        };
        _context.ParkingSessions.Add(session);
        await _context.SaveChangesAsync();
        return Ok(new{session.Id, session.TapInTime, session.PlateNumber});
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> TapOut([FromBody] TapOutRequest request)
    {
        var session =
            await _context.ParkingSessions.FirstOrDefaultAsync(s =>
                s.PlateNumber == request.PlateNumber && s.TapOutTime == null);
        
        if(session == null) return NotFound("session not found");
        
        session.TapOutTime = DateTime.UtcNow;
        session.OutTapOperatorId = request.OperatorId;
        
        //Get Active rate
        var rate = await _context.ParkingRates.OrderByDescending(r=> r.EffectiveFrom).FirstOrDefaultAsync();

        if (rate != null)
        {
            var duration = session.TapOutTime.Value - session.TapInTime;
            var days = (int)Math.Ceiling(duration.TotalDays);
            var hours = (int)Math.Ceiling(duration.TotalHours);
            var fee = rate.FirstHourRate + ((hours - 1) * rate.NextHourRate);

            if (fee > rate.DailyMaxRate) fee = rate.DailyMaxRate;
            if(days > 1) fee += (days - 1) * rate.OverDuePinaltyPerDay;
            
            session.FinalFee = fee;
        }
        
        await _context.SaveChangesAsync();
        return Ok(session);
    }
}

public class TapInRequest
{
    public string PlateNumber { get; set; }
    public int OperatorId { get; set; }
}

public class TapOutRequest
{
    public string PlateNumber { get; set; }
    public int OperatorId { get; set; }
}