using GolfWebApi.Data;
using GolfWebApi.Models;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;
using Microsoft.EntityFrameworkCore;
using MimeKit;
using MimeKit.Text;
using SQLitePCL;
using System.IO;
using System.Net.Http.Headers;

namespace NewEgolfAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembersController : ControllerBase
    {
        private readonly DataContext _context;
        private IWebHostEnvironment webHostEnvironment;

        public MembersController(DataContext context, IWebHostEnvironment env)
        {
            this.webHostEnvironment= env;
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
            //string newPic = "test.jpeg";

            if (id != member.Id)
            {
                return BadRequest();
            }
            // check if email and GGAID already exist
            var existingMember = _context.Members.FirstOrDefault(x => x.Email == member.Email && x.Id != id && x.Ggaid != member.Ggaid);
            if (existingMember != null) { return BadRequest("Email is already taken."); }
            //member.Picture=saveImage(member?.Picture);

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



        [NonAction]
        public async Task<string> UploadImage(IFormFile? imageFile)
        {

            var mes = "No file was selected";

            if (imageFile != null)
            {
                try
                {
                    string imageName = new string(Path.GetFileNameWithoutExtension(imageFile.FileName).Take(10).ToArray()).Replace(' ', '-');
                    imageName = imageName + DateTime.Now.ToString("yymmssfff") + Path.GetExtension(imageFile.FileName);
                    var imagePath = Path.Combine(webHostEnvironment.ContentRootPath, "Uploads/Member", imageName);

                    using (var fileStream = new FileStream(imagePath, FileMode.Create))
                    {
                        await imageFile.CopyToAsync(fileStream);
                    }
                    return imageName;
                }
                catch (Exception e)
                {

                    return e.ToString();
                }
            }
            return mes;

        }

        // POST: api/Members
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Member>> PostMember([FromForm] MemberCreateDto memberDto)
        {
            if (_context.Members == null)
            {
              return Problem("Entity set 'DataContext.Members'  is null.");
            }
<<<<<<< HEAD
            var checkMember = _context.Members.Where(te => te.Code == member.Code || te.Email==member.Email || te.Ggaid==member.Ggaid ).FirstOrDefault();
            if (checkMember != null)
            {
                return BadRequest("Member Already Exist");
            } 
=======
            memberDto.ImageUrl = await UploadImage(memberDto.ImageFile);
            var employee = mapper.Map<Member>(memberDto);

>>>>>>> c911750289c4123d78aa074df624f45645842463
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse("egolfplatform@gmail.com"));
            email.To.Add(MailboxAddress.Parse(member.Email));
            email.Subject = "Activation Code";
            //generate random code
            //var code = new Random().Next(100000, 999999);
            //member.Code = code.ToString();
                
            email.Body = new TextPart(TextFormat.Plain)
            {
                Text = $"Your activation code is {member.Code}"
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
