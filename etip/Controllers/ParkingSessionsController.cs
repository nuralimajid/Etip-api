using etip.Data;
using etip.DTOs;
using etip.Models;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace etip.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ParkingSessionsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ParkingSessionsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/ParkingSessions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ParkingSessionDto>>> GetParkingSessions()
        {
            return await _context.ParkingSessions.ProjectToType<ParkingSessionDto>().ToListAsync();
        }

        // GET: api/ParkingSessions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ParkingSessionDto>> GetParkingSession(int id)
        {
            var parkingSession = await _context.ParkingSessions.FindAsync(id);

            if (parkingSession == null)
            {
                return NotFound();
            }

            return parkingSession.Adapt<ParkingSessionDto>();
        }

        // POST: api/ParkingSessions/checkin
        [HttpPost("checkin")]
        public async Task<ActionResult<ParkingSessionDto>> CheckIn(ParkingSessionDto parkingSessionDto)
        {
            var parkingSession = parkingSessionDto.Adapt<ParkingSession>();
            parkingSession.CheckInTime = DateTime.UtcNow;

            _context.ParkingSessions.Add(parkingSession);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetParkingSession", new { id = parkingSession.Id }, parkingSession.Adapt<ParkingSessionDto>());
        }

        // PUT: api/ParkingSessions/checkout/5
        [HttpPut("checkout/{id}")]
        public async Task<IActionResult> CheckOut(int id, ParkingSessionDto parkingSessionDto)
        {
            if (id != parkingSessionDto.Id)
            {
                return BadRequest();
            }

            var parkingSession = await _context.ParkingSessions.FindAsync(id);
            if (parkingSession == null)
            {
                return NotFound();
            }

            parkingSessionDto.Adapt(parkingSession);
            parkingSession.CheckOutTime = DateTime.UtcNow;

            // Calculate fee
            var parkingRate = await _context.ParkingRates.FirstOrDefaultAsync(); // Get the first rate for simplicity
            if (parkingRate != null && parkingSession.CheckInTime.HasValue)
            {
                var duration = (parkingSession.CheckOutTime.Value - parkingSession.CheckInTime.Value);
                var totalHours = (int)Math.Ceiling(duration.TotalHours);

                if (totalHours <= 1)
                {
                    parkingSession.TotalFee = parkingRate.FirstHourRate;
                }
                else
                {
                    parkingSession.TotalFee = parkingRate.FirstHourRate + (totalHours - 1) * parkingRate.NextHourRate;
                }

                if (parkingSession.TotalFee > parkingRate.DailyMaxRate)
                {
                    parkingSession.TotalFee = parkingRate.DailyMaxRate;
                }
            }

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ParkingSessionExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        private bool ParkingSessionExists(int id)
        {
            return _context.ParkingSessions.Any(e => e.Id == id);
        }
    }
}
