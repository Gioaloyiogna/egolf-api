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
    public class GameTypesController : ControllerBase
    {
        private readonly DataContext _context;

        public GameTypesController(DataContext context)
        {
            _context = context;
        }

        // GET: api/GameTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GameType>>> GetGameTypes()
        {
          if (_context.GameTypes == null)
          {
              return NotFound();
          }
            return await _context.GameTypes.ToListAsync();
        }

        // GET: api/GameTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GameType>> GetGameType(long id)
        {
          if (_context.GameTypes == null)
          {
              return NotFound();
          }
            var gameType = await _context.GameTypes.FindAsync(id);

            if (gameType == null)
            {
                return NotFound();
            }

            return gameType;
        }

        // PUT: api/GameTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGameType(long id, GameType gameType)
        {
            if (id != gameType.Id)
            {
                return BadRequest();
            }

            _context.Entry(gameType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GameTypeExists(id))
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

        // POST: api/GameTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<GameType>> PostGameType(GameType gameType)
        {
          if (_context.GameTypes == null)
          {
              return Problem("Entity set 'DataContext.GameTypes'  is null.");
          }
            _context.GameTypes.Add(gameType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGameType", new { id = gameType.Id }, gameType);
        }

        // DELETE: api/GameTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGameType(long id)
        {
            if (_context.GameTypes == null)
            {
                return NotFound();
            }
            var gameType = await _context.GameTypes.FindAsync(id);
            if (gameType == null)
            {
                return NotFound();
            }

            _context.GameTypes.Remove(gameType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GameTypeExists(long id)
        {
            return (_context.GameTypes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
