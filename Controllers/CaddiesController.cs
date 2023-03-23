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
    public class CaddiesController : ControllerBase
    {
        private readonly DataContext _context;

        public CaddiesController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Caddies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Caddy>>> GetCaddies()
        {
          if (_context.Caddies == null)
          {
              return NotFound();
          }
            return await _context.Caddies.ToListAsync();
        }

        // GET: api/Caddies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Caddy>> GetCaddy(int id)
        {
          if (_context.Caddies == null)
          {
              return NotFound();
          }
            var caddy = await _context.Caddies.FindAsync(id);

            if (caddy == null)
            {
                return NotFound();
            }

            return caddy;
        }

        // PUT: api/Caddies/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCaddy(int id, Caddy caddy)
        {
            if (id != caddy.Id)
            {
                return BadRequest();
            }

            _context.Entry(caddy).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CaddyExists(id))
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

        // POST: api/Caddies
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Caddy>> PostCaddy(Caddy caddy)
        {
          if (_context.Caddies == null)
          {
              return Problem("Entity set 'DataContext.Caddies'  is null.");
          }
            _context.Caddies.Add(caddy);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCaddy", new { id = caddy.Id }, caddy);
        }

        // DELETE: api/Caddies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCaddy(int id)
        {
            if (_context.Caddies == null)
            {
                return NotFound();
            }
            var caddy = await _context.Caddies.FindAsync(id);
            if (caddy == null)
            {
                return NotFound();
            }

            _context.Caddies.Remove(caddy);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CaddyExists(int id)
        {
            return (_context.Caddies?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
