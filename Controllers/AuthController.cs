using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GolfWebApi.Data;
using GolfWebApi.Models;
using GolfWebApi.Settings;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Azure.Core;
using GolfWebApi.Dtos;
using DevExpress.XtraPrinting.Native.Caching;
using System.Security.Cryptography;

namespace GolfWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly  IConfiguration _configuration;
        public AuthController(DataContext context,IConfiguration configuration)
        {
            _context = context;
            _configuration= configuration;
        }

        // GET: api/Auth
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Member>>> GetMembers()
        {
          if (_context.Members == null)
          {
              return NotFound();
          }
            return await _context.Members.ToListAsync();
        }

        // GET: api/Auth/5
        //[HttpGet("{token}")]
        //public async Task<ActionResult<Member>> GetMember(string token)
        //{


          //if (_context.Members == null)
          //{
          //    return NotFound();
          //}
          //  var member = await _context.Members.FindAsync(id);

          //  if (member == null)
          //  {
          //      return NotFound();
          //  }

          //  return member;
        //}

        // PUT: api/Auth/5
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

        // POST: api/Auth
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<TokenDto> Login(LoginDto login)
        {
            if (login.role == "member")
            {
                if (_context.Members == null)
                {
                    return new TokenDto { api_token = null };
                }

                Member member = await _context.Members.Where(te => te.Email == login.email).FirstOrDefaultAsync();

                if (member == null)
                {
                    return new TokenDto { api_token = null };
                }

                try
                {
                    //var refreshToken = GenerateRefreshToken();

                    //setRefreshToken(refreshToken);
                    return new TokenDto
                    {
                        api_token = createJwt(member)
                    };
                }
                catch (Exception ex)
                {
                    return new TokenDto { api_token = null };
                }
            }
            // for caddies
            if (login.role == "caddy")
            {
                if (_context.Caddies == null)
                {
                    return new TokenDto { api_token = null };
                }

                Caddy caddyObj = await  _context.Caddies.Where(te => te.Email == login.email).FirstOrDefaultAsync();

                if (caddyObj == null)
                {
                    return new TokenDto { api_token = null };
                }

                try
                {
                    //var refreshToken = GenerateRefreshToken();

                    //setRefreshToken(refreshToken);
                    return new TokenDto
                    {
                        api_token = createJwtCaddy(caddyObj )
                    };
                }
                catch (Exception ex)
                {
                    return new TokenDto { api_token = null };
                }
            }
            return new TokenDto { api_token = null };
        }
        //private TokenDto GetRefreshToken()
        //{
        //    var refreshToken = new TokenDto
        //    {
        //        Token = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64))
        //    };
        //    return refreshToken;
        //}

        [NonAction]
        private string createJwt(Member member)
        {

            List<Claim> claims = new List<Claim>()
              {

                      new Claim("Code", member.Code),
                      new Claim("Fullname", member?.Fname+' '+member.Lname),
                      new Claim("Email", member.Email),
                      new Claim("PlayerHandicap", member.PlayerHandicap),
                      new Claim("Ggaid", member.Ggaid),


              };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value!));

            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddMinutes(20),
                signingCredentials: credentials

                );
            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
        }
        [NonAction]
        private string createJwtCaddy(Caddy caddy)
        {

            List<Claim> claims = new List<Claim>()
              {

                      new Claim("Code", caddy.Code),
                      new Claim("Fullname", caddy.Fname+' '+caddy.Lname),
                      new Claim("Email", caddy.Email),
                      


              };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value!));

            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddMinutes(20),
                signingCredentials: credentials

                );
            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
        }



        // DELETE: api/Auth/5
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
