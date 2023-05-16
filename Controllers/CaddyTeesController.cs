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
    public class CaddyTeesController : ControllerBase
    {
        private readonly DataContext _context;

        public CaddyTeesController(DataContext context)
        {
            _context = context;
        }

        // GET: api/CaddyTees
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CaddyTee>>> GetCaddyTees()
        {
          if (_context.CaddyTees == null)
          {
              return NotFound();
          }
            return await _context.CaddyTees.ToListAsync();
        }

        // GET: api/CaddyTees/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CaddyTee>> GetCaddyTee(int id)
        {
          if (_context.CaddyTees == null)
          {
              return NotFound();
          }
            var caddyTee = await _context.CaddyTees.FindAsync(id);

            if (caddyTee == null)
            {
                return NotFound();
            }

            return caddyTee;
        }

        // PUT: api/CaddyTees/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCaddyTee(int id, CaddyTee caddyTee)
        {
            if (id != caddyTee.Id)
            {
                return BadRequest();
            }

            _context.Entry(caddyTee).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CaddyTeeExists(id))
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

        // POST: api/CaddyTees
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CaddyTee>> PostCaddyTee(CaddyTee caddyTee)
        {
          if (_context.CaddyTees == null)
          {
              return Problem("Entity set 'DataContext.CaddyTees'  is null.");
          }
            _context.CaddyTees.Add(caddyTee);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCaddyTee", new { id = caddyTee.Id }, caddyTee);
        }

        // DELETE: api/CaddyTees/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCaddyTee(int id)
        {
            if (_context.CaddyTees == null)
            {
                return NotFound();
            }
            var caddyTee = await _context.CaddyTees.FindAsync(id);
            if (caddyTee == null)
            {
                return NotFound();
            }

            _context.CaddyTees.Remove(caddyTee);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CaddyTeeExists(int id)
        {
            return (_context.CaddyTees?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
