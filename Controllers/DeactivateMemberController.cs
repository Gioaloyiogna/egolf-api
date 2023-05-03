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
    public class DeactivateMemberController : ControllerBase
    {
        private readonly DataContext _context;

        public DeactivateMemberController(DataContext context)
        {
            _context = context;
        }

        // GET: api/DeactivateMember
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Member>>> GetMembers()
        {
          if (_context.Members == null)
          {
              return NotFound();
          }
            return await _context.Members.ToListAsync();
        }

        // GET: api/DeactivateMember/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Member>> GetMember(long id)
        {
          if (_context.Members == null)
          {
              return NotFound();
          }
            var member = await _context.Members.FindAsync(id);

            if (member == null)
            {
                return NotFound();
            }

            return member;
        }

        // PUT: api/DeactivateMember/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMember(long id, Member member)
        {
            if (id != member.Id)
            {
                return BadRequest();
            }

            _context.Entry(member).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MemberExists(id))
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

        // POST: api/DeactivateMember
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754

        [HttpPost]
        public async Task<IActionResult> DeactivateMember(long id)
        {
            try
            {
                var Member = await _context.Members.FindAsync(id);
                if (Member != null)
                {
                    Member.Status = "Inactive";
                    await _context.SaveChangesAsync();

                    var email = new MimeMessage();
                    email.From.Add(MailboxAddress.Parse("egolfplatform@gmail.com"));
                    email.To.Add(MailboxAddress.Parse(Member.Email));
                    email.Subject = "Suspension from Egolf";


                    email.Body = new TextPart(TextFormat.Plain)
                    {
                        Text = " Please note  that you've been suspended from the egolf platform!"
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
                else
                {
                    return NotFound();
                }

            }

            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while deactivating the member: {ex.Message}");
            }
        }

        // DELETE: api/DeactivateMember/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMember(long id)
        {
            if (_context.Members == null)
            {
                return NotFound();
            }
            var member = await _context.Members.FindAsync(id);
            if (member == null)
            {
                return NotFound();
            }

            _context.Members.Remove(member);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MemberExists(long id)
        {
            return (_context.Members?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
