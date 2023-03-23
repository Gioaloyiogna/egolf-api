using GolfWebApi.Data;
using GolfWebApi.Models;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using MimeKit.Text;

namespace NewEgolfAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembersController : ControllerBase
    {
        private readonly DataContext _context; 

        public MembersController(DataContext context)
        {
            _context = context; 
        }

        // GET: api/Members
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Member>>> GetMembers()
        {
            if (_context.Members == null) 
            { 
                return NotFound(); 
            }

            return await _context.Members.ToListAsync();
        } 

        // GET: api/Members/5
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

        // PUT: api/Members/5
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

        // POST: api/Members
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Member>> PostMember(Member member)
        {
            if (_context.Members == null)
            {
              return Problem("Entity set 'DataContext.Members'  is null.");
            }

            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse("egolfplatform@gmail.com"));
            email.To.Add(MailboxAddress.Parse(member.Email));
            email.Subject = "Activation Code";
            //generate random code
            var code = new Random().Next(100000, 999999);
            member.Code = code.ToString();
                
            email.Body = new TextPart(TextFormat.Plain)
            {
                Text = $"Your activation code is {code}"
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

            _context.Members.Add(member);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMember", new { id = member.Id }, member);
        }

        // DELETE: api/Members/5
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
