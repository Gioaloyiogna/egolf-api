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
using System.Security.Cryptography;
using Microsoft.AspNetCore.Identity;
using NuGet.Protocol.Plugins;

namespace GolfWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly  IConfiguration _config;
        public AuthController(DataContext context,IConfiguration configuration)
        {
            _context = context;
            _config= configuration;
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
        public IActionResult Login( LoginDto loginDto)
        {
            //for member auth
            if (loginDto.role =="member")
            {
                try
                {
                    TokenDto tokenResponse = new TokenDto();
                   var curMember = _context.Members.Where(m => m.Email == loginDto.email && m.Code == loginDto.code).FirstOrDefault();


                    if (curMember != null)
                    {
                        var token = GenerateMemberToken(curMember);
                        tokenResponse.api_token = token;
                        return Ok(tokenResponse);
                    }
                    return BadRequest("You are not a member");
                }
                catch (Exception e)
                {
                    return BadRequest($"Error, can not login ,{e.Message}");
                }
            }
            

            //for caddy auth
            if (loginDto.role =="caddy")
            {
                try
                {
                    TokenDto tokenResponse = new TokenDto();
                   var curCaddy = _context.Caddies.Where(m => m.Email == loginDto.email && m.Code == loginDto.code).FirstOrDefault();

                    if (curCaddy != null)
                    {
                        var token = GenerateCaddyToken(curCaddy);
                        tokenResponse.api_token = token;
                        return Ok(tokenResponse);
                    }
                    return BadRequest("You are not a caddy");
                }
                catch (Exception e)
                {
                    return BadRequest($"Error, can not login {e.Message}");
                }
            }
            return BadRequest("Failed to login, enter a role and email!");
        }


        [NonAction]
        private string GenerateMemberToken(Member member)
        {
            var claims = new[]
            {
                new Claim("Code", member.Code + ""),
                new Claim("Fullname", member.Fname+' '+member.Lname),
                new Claim("Email", member.Email + ""),
                new Claim("PlayerHandicap", member.PlayerHandicap + ""),
                new Claim("Ggaid", member.Ggaid + ""),

            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("Jwt:Token").Value!));

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
        private string GenerateCaddyToken(Caddy caddy)
        {

            var claims = new[]
            {
                new Claim("Code", caddy.Code),
                new Claim("Fullname", caddy.Fname+' '+caddy.Lname),
                new Claim("Email", caddy.Email),

            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("Jwt:Token").Value!));

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
