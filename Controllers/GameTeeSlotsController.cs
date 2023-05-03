using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GolfWebApi.Data;
using GolfWebApi.Models;
using Microsoft.VisualBasic;

namespace GolfWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameTeeSlotsController : ControllerBase
    {
        private readonly DataContext _context;

        public GameTeeSlotsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/GameTeeSlots
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DateTime>>> GetTeeSlots()
        {
            DateTime oneWeekAgo = DateTime.UtcNow.AddDays(-7);

            if (_context.TeeSlots == null)
          {
              return NotFound();
          }
            var teeSlot =await _context.TeeSlots.Select(t => DateTime.Parse(t.teeTime)).Distinct().ToListAsync();
            return teeSlot;
        }

        // GET: api/GameTeeSlots/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TeeSlot>> GetTeeSlot(int id)
        {
          if (_context.TeeSlots == null)
          {
              return NotFound();
          }
            var teeSlot = await _context.TeeSlots.FindAsync(id);

            if (teeSlot == null)
            {
                return NotFound();
            }

            return teeSlot;
        }

        // PUT: api/GameTeeSlots/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTeeSlot(int id, TeeSlot teeSlot)
        {
            if (id != teeSlot.Id)
            {
                return BadRequest();
            }

            _context.Entry(teeSlot).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TeeSlotExists(id))
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

        // POST: api/GameTeeSlots
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TeeSlot>> PostTeeSlot(TeeSlot teeSlot)
        {
          if (_context.TeeSlots == null)
          {
              return Problem("Entity set 'DataContext.TeeSlots'  is null.");
          }
            _context.TeeSlots.Add(teeSlot);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTeeSlot", new { id = teeSlot.Id }, teeSlot);
        }

        // DELETE: api/GameTeeSlots/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTeeSlot(int id)
        {
            if (_context.TeeSlots == null)
            {
                return NotFound();
            }
            var teeSlot = await _context.TeeSlots.FindAsync(id);
            if (teeSlot == null)
            {
                return NotFound();
            }

            _context.TeeSlots.Remove(teeSlot);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TeeSlotExists(int id)
        {
            return (_context.TeeSlots?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
