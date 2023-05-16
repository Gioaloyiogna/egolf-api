using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GolfWebApi.Data;
using GolfWebApi.Models;
using MimeKit.Text;
using MimeKit;
using MailKit.Net.Smtp;
namespace GolfWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NonMemberTeeSlotsController : ControllerBase
    {
        private readonly DataContext _context;

        public NonMemberTeeSlotsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/NonMemberTeeSlots
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TeeSlot>>> GetTeeSlots()
        {
          if (_context.TeeSlots == null)
          {
              return NotFound();
          }
            return await _context.TeeSlots.ToListAsync();
        }

        // GET: api/NonMemberTeeSlots/5
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

        // PUT: api/NonMemberTeeSlots/5
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

        // POST: api/NonMemberTeeSlots
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TeeSlot>> PostTeeSlot(TeeSlot teeSlot)
        {
            try
            {
                var memberExists = _context.TeeSlots.Where(te => te.playerEmail == teeSlot.playerEmail && te.teeTime == teeSlot.teeTime);
                var availableSlot = _context.TeeSlots.Where(te => te.teeTime == teeSlot.teeTime).Count();
                if (_context.TeeSlots == null)
                {
                    return Problem("Entity set 'DataContext.TeeSlots'  is null.");
                }

                // checking if member exists

                if (memberExists.Any()) { return StatusCode(500, "Member already exists"); }
                // checking for available slots
                if (availableSlot >= 4)
                {
                    return StatusCode(500, "No available space");
                }


                var newMember = new TeeSlot
                {

                    playerType = teeSlot.playerType,
                    playerEmail = teeSlot.playerEmail,
                    teeTime = teeSlot.teeTime,
                    playerName = teeSlot.playerName,
                    availabilityStatus = teeSlot.availabilityStatus,
                    caddyId = teeSlot.caddyId

                };

                _context.TeeSlots.Add(newMember);
                await _context.SaveChangesAsync();

                var email = new MimeMessage();
                email.From.Add(MailboxAddress.Parse("egolfplatform@gmail.com"));
                email.To.Add(MailboxAddress.Parse(teeSlot.playerEmail));
                email.Subject = "Activation on Egolf platform";
                email.Body = new TextPart(TextFormat.Plain)
                {
                    Text = $"Note that you've been scheduled for a game on the Egolf platform, happening at {teeSlot.teeTime}!"
                };

                using var smtp = new SmtpClient();
                try
                {
                    smtp.Connect("smtp.gmail.com", 587, false);
                    smtp.Authenticate("egolfplatform@gmail.com", "fyumihoxdjxngfwa");
                    smtp.Send(email);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw new Exception("Problem sending mail", e);
                }
                finally
                {
                    smtp.Disconnect(true);
                }
                return Ok();

            }

        

            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while adding  member: {ex.Message}");
    }
}

        // DELETE: api/NonMemberTeeSlots/5
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
        [HttpDelete("{email}/{teeTime}")]
        public async Task<IActionResult> DeleteTeeSlot(string email, string teeTime)
        {
            if (_context.TeeSlots == null)
            {
                return NotFound();
            }
            //var teeSlot = await _context.TeeSlots.FindAsync(id);
            var teeSlot = await _context.TeeSlots.Where(m => m.playerEmail == email && m.teeTime == teeTime).FirstOrDefaultAsync();
            if (teeSlot == null)
            {
                return BadRequest("Non Member does not exist");
            }

            _context.TeeSlots.Remove(teeSlot);
            await _context.SaveChangesAsync();

            return Ok();
        }

        private bool TeeSlotExists(int id)
        {
            return (_context.TeeSlots?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
