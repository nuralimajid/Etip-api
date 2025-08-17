using etip.Data;
using etip.DTOs;
using etip.Models;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace etip.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class GatesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public GatesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Gates
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GateDto>>> GetGates()
        {
            return await _context.Gates.ProjectToType<GateDto>().ToListAsync();
        }

        // GET: api/Gates/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GateDto>> GetGate(int id)
        {
            var gate = await _context.Gates.FindAsync(id);

            if (gate == null)
            {
                return NotFound();
            }

            return gate.Adapt<GateDto>();
        }

        // PUT: api/Gates/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGate(int id, GateDto gateDto)
        {
            if (id != gateDto.Id)
            {
                return BadRequest();
            }

            var gate = await _context.Gates.FindAsync(id);
            if (gate == null)
            {
                return NotFound();
            }

            gateDto.Adapt(gate);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GateExists(id))
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

        // POST: api/Gates
        [HttpPost]
        public async Task<ActionResult<GateDto>> PostGate(GateDto gateDto)
        {
            var gate = gateDto.Adapt<Gate>();
            _context.Gates.Add(gate);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGate", new { id = gate.Id }, gate.Adapt<GateDto>());
        }

        // DELETE: api/Gates/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGate(int id)
        {
            var gate = await _context.Gates.FindAsync(id);
            if (gate == null)
            {
                return NotFound();
            }

            _context.Gates.Remove(gate);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GateExists(int id)
        {
            return _context.Gates.Any(e => e.Id == id);
        }
    }
}
