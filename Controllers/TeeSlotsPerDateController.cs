using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GolfWebApi.Data;
using GolfWebApi.Models;

namespace GolfWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeeSlotsPerDateController : ControllerBase
    {
        private readonly DataContext _context;

        public TeeSlotsPerDateController(DataContext context)
        {
            _context = context;
        }

        // GET: api/TeeSlotsPerDate
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TeeSlot>>> GetTeeSlots()
        {
          if (_context.TeeSlots == null)
          {
              return NotFound();
          }
            return await _context.TeeSlots.ToListAsync();
        }

        // GET: api/TeeSlots/5
        [HttpGet("{teeDate}")]
        public ActionResult<int> GetTeeSlotNumber(string teeDate)
        {
            if (_context.TeeSlots == null)
            {
                return NotFound();
            }
            
            

            var teeSlot= _context.TeeSlots.Where(te => te.teeTime.Contains(teeDate)).Select(t => t.teeTime).Distinct().Count();
            
            
            if (teeSlot == 0)
            {
                return teeSlot;
            }
         
            return teeSlot;
        }

        // PUT: api/TeeSlotsPerDate/5
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

        // POST: api/TeeSlotsPerDate
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

        // DELETE: api/TeeSlotsPerDate/5
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
