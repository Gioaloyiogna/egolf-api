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
    public class HolestblsController : ControllerBase
    {
        private readonly DataContext _context;

        public HolestblsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Holestbls
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Holestbl>>> GetHoletbls()
        {
          if (_context.Holetbls == null)
          {
              return NotFound();
          }
            return await _context.Holetbls.ToListAsync();
        }

        // GET: api/Holestbls/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Holestbl>> GetHolestbl(int id)
        {
          if (_context.Holetbls == null)
          {
              return NotFound();
          }
            var holestbl = await _context.Holetbls.FindAsync(id);

            if (holestbl == null)
            {
                return NotFound();
            }

            return holestbl;
        }

        // PUT: api/Holestbls/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHolestbl(int id, Holestbl holestbl)
        {
            if (id != holestbl.Id)
            {
                return BadRequest();
            }

            _context.Entry(holestbl).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HolestblExists(id))
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

        // POST: api/Holestbls
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Holestbl>> PostHolestbl(Holestbl holestbl)
        {
          if (_context.Holetbls == null)
          {
              return Problem("Entity set 'DataContext.Holetbls'  is null.");
          }
            _context.Holetbls.Add(holestbl);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHolestbl", new { id = holestbl.Id }, holestbl);
        }

        // DELETE: api/Holestbls/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHolestbl(int id)
        {
            if (_context.Holetbls == null)
            {
                return NotFound();
            }
            var holestbl = await _context.Holetbls.FindAsync(id);
            if (holestbl == null)
            {
                return NotFound();
            }

            _context.Holetbls.Remove(holestbl);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HolestblExists(int id)
        {
            return (_context.Holetbls?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
