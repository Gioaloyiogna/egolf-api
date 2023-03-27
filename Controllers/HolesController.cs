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
    public class HolesController : ControllerBase
    {
        private readonly DataContext _context;

        public HolesController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Holes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Hole>>> GetHoles()
        {
          if (_context.Holes == null)
          {
              return NotFound();
          }
            return await _context.Holes.ToListAsync();
        }

        // GET: api/Holes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Hole>> GetHole(int id)
        {
          if (_context.Holes == null)
          {
              return NotFound();
          }
            var hole = await _context.Holes.FindAsync(id);

            if (hole == null)
            {
                return NotFound();
            }

            return hole;
        }

        // PUT: api/Holes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHole(int id, Hole hole)
        {
            if (id != hole.Id)
            {
                return BadRequest();
            }

            _context.Entry(hole).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HoleExists(id))
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

        // POST: api/Holes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Hole>> PostHole(Hole hole)
        {
          if (_context.Holes == null)
          {
              return Problem("Entity set 'DataContext.Holes'  is null.");
          }
            _context.Holes.Add(hole);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHole", new { id = hole.Id }, hole);
        }

        // DELETE: api/Holes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHole(int id)
        {
            if (_context.Holes == null)
            {
                return NotFound();
            }
            var hole = await _context.Holes.FindAsync(id);
            if (hole == null)
            {
                return NotFound();
            }

            _context.Holes.Remove(hole);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HoleExists(int id)
        {
            return (_context.Holes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
