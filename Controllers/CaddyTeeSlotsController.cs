using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GolfWebApi.Data;
using GolfWebApi.Models;
using NuGet.Protocol;

namespace GolfWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CaddyTeeSlotsController : ControllerBase
    {
        private readonly DataContext _context;

        public CaddyTeeSlotsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/CaddyTeeSlots
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TeeSlot>>> GetTeeSlots()
        {
          if (_context.TeeSlots == null)
          {
              return NotFound();
          }
            return await _context.TeeSlots.ToListAsync();
        }

        // GET: api/CaddyTeeSlots/5
        [HttpGet("{teeTime}")]
        public async Task<ActionResult<Caddy>> GetTeeSlot(string teeTime)
        {
          if (_context.TeeSlots == null)
          {
              return NotFound();
          }
            if (_context.Caddies == null)
            {
                return NotFound();
            }
            var teeSlot = await _context.TeeSlots.Where(te=>te.teeTime ==teeTime).FirstOrDefaultAsync();
            Caddy? caddy =null;
            if (teeSlot != null)
            {
                 caddy= await  _context.Caddies.Where(te => te.Id == teeSlot.caddyId).FirstOrDefaultAsync();
            }

            if (caddy == null)
            {
                return  StatusCode(500);
            }

            return caddy;
        }

        // PUT: api/CaddyTeeSlots/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{teeTime}")]
        public async Task<IActionResult> PutTeeSlot(string teeTime, TeeSlot teeSlot)
        {
            if ( teeTime != teeSlot.teeTime)
            {
                return BadRequest();
            }
            var tees = _context.TeeSlots.Where(te => te.teeTime == teeSlot.teeTime).ToArrayAsync();
            
            if(tees != null)
            {
                foreach (var tee in await tees)
                {
                   tee.caddyId= teeSlot.caddyId;
                    _context.Entry(tee).State = EntityState.Modified;
                }
            }
            

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return NoContent();
        }


        // POST: api/CaddyTeeSlots
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

        // DELETE: api/CaddyTeeSlots/5
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
