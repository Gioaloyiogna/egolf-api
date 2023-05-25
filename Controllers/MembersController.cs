using AutoMapper;
using GolfWebApi.Data;
using GolfWebApi.Dtos;
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
        private readonly IMapper mapper;

        public MembersController(DataContext context,IMapper mapper, IWebHostEnvironment env)
        {
            this.webHostEnvironment= env;
            this.mapper = mapper;
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
        public async Task<IActionResult> PutMember(long id, [FromForm] MemberDto memberDto)
        {

            var existingMember = _context.Members.FirstOrDefault(x => (x.Email == memberDto.Email || x.Ggaid == memberDto.Ggaid || x.MembershipId == memberDto.MembershipId) && x.Id != memberDto.Id );
            var memberPic = _context.Members.FirstOrDefault(x => x.Email == memberDto.Email && x.Id==memberDto.Id);
            if (existingMember != null) { return BadRequest("Email is already taken."); }

            if (memberDto.ImageFile == null)
            {
                memberDto.Picture = memberPic?.Picture !=null? memberPic?.Picture:"";
            }
            else
            {
                memberDto.Picture = await UploadImage(memberDto.ImageFile);
            }
           
            var member = mapper.Map<Member>(memberDto);


             // Detach existing tracked entity with the same key value
            var existingTrackedMember = _context.Members.Find(memberDto.Id);
            if (existingTrackedMember != null)
            {
                _context.Entry(existingTrackedMember).State = EntityState.Detached;
            }

            _context.Entry(member).State = EntityState.Modified;


            try
            {
                //_context.Entry(member).Reload();

                await _context.SaveChangesAsync();

            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MemberExists(memberDto.Id))
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
        public async Task<ActionResult<Member>> PostMember([FromForm] MemberDto memberDto)
        {
            if (_context.Members == null)
            {
              return Problem("Entity set 'DataContext.Members'  is null.");
            }

            memberDto.Picture = await UploadImage(memberDto.ImageFile);
            var member = mapper.Map<Member>(memberDto);
            //var random = new Random();
            //string randomNumber = string.Empty;
            //for (int i = 0; i < 4; i++)
            //{
            //    randomNumber = String.Concat(randomNumber, random.Next(10).ToString());
            //}
            //var checkCode = _context.Members.Where(te => te.Code == s).FirstAsync();
            //if(checkCode != null)
            //{
            //    for (int i = 0; i < 3; i++)
            //    {
            //        s = String.Concat(s, random.Next(10).ToString());
            //    }
            //}

            var checkMember = _context.Members.Where(te => te.MembershipId == memberDto.Code || te.Email== memberDto.Email || te.Ggaid== memberDto.Ggaid ).FirstOrDefault();
            if (checkMember != null)
            {
                return BadRequest("Member Already Exist");
            } 

            
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse("egolfplatform@gmail.com"));
            email.To.Add(MailboxAddress.Parse(memberDto.Email));
            email.Subject = "Activation Code";
            //generate random code
            var code = new Random().Next(1000, 9999);
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
        
            member.MembershipId= memberDto.Code;
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
