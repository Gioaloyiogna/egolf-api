using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GolfWebApi.Data;
using GolfWebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;    

namespace GolfWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameSchedulesController : ControllerBase
    {
        private readonly DataContext _context;

        public GameSchedulesController(DataContext context)
        {
            _context = context;
        }

        // GET: api/GameSchedules
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GameSchedule>>> GetGameSchedules()
        {
          if (_context.GameSchedules == null)
          {
              return NotFound();
          }
          return await _context.GameSchedules.ToListAsync();
        }

        // GET: api/GameSchedules/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GameSchedule>> GetGameSchedule(long id)
        {
          if (_context.GameSchedules == null)
          {
              return NotFound();
          }
          var gameSchedule = await _context.GameSchedules.FindAsync(id);

            if (gameSchedule == null)
            {
                return NotFound();
            }

            return gameSchedule;
        }

        // PUT: api/GameSchedules/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGameSchedule(long id, GameSchedule gameSchedule)
        {
            if (id != gameSchedule.Id)
            {
                return BadRequest();
            }

            _context.Entry(gameSchedule).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GameScheduleExists(id))
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

        // POST: api/GameSchedules
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<GameSchedule>> PostGameSchedule(GameSchedule gameSchedule)
        {
          if (_context.GameSchedules == null)
          {
              return Problem("Entity set 'DataContext.GameSchedules'  is null.");
          }
            _context.GameSchedules.Add(gameSchedule);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGameSchedule", new { id = gameSchedule.Id }, gameSchedule);
        }

        // DELETE: api/GameSchedules/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGameSchedule(long id)
        {
            if (_context.GameSchedules == null)
            {
                return NotFound();
            }
            var gameSchedule = await _context.GameSchedules.FindAsync(id);
            if (gameSchedule == null)
            {
                return NotFound();
            }

            _context.GameSchedules.Remove(gameSchedule);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GameScheduleExists(long id)
        {
            return (_context.GameSchedules?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
