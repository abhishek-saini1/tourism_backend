﻿using Humanizer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Tourism.Models;

namespace Tourism.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly TourismDbContext _context;

        public TokenController(IConfiguration config, TourismDbContext context)
        {
            _configuration = config;
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Login _userData)
        {
            if (_userData != null && !string.IsNullOrEmpty(_userData.Username) && !string.IsNullOrEmpty(_userData.Password))
            {
                var administrator = await GetAdministrator(_userData.Username, _userData.Password);
                var traveler = await GetTraveler(_userData.Username, _userData.Password);
                var travelAgent = await GetTravelAgent(_userData.Username, _userData.Password);

                if (administrator != null)
                {
                    return GenerateTokenForUser(administrator, "Admin");
                }
                else if (traveler != null)
                {
                    return GenerateTokenForUser(traveler, "Traveler");
                }
                else if (travelAgent != null)
                {
                    return GenerateTokenForUser(travelAgent, "TravelAgent");
                }
                else
                {
                    return BadRequest("Invalid credentials");
                }
            }
            else
            {
                return BadRequest("Invalid credentials");
            }
        }

        private async Task<Admin> GetAdministrator(string username, string password)
        {

            return await _context.admins.FirstOrDefaultAsync(a => a.AUserName == username && a.APassword == password);
        }

        private async Task<Traveler> GetTraveler(string username, string password)
        {

            return await _context.travelers.FirstOrDefaultAsync(t => t.Username == username && t.Password == password);
        }

        private async Task<Agent> GetTravelAgent(string username, string password)
        {

            return await _context.agents.FirstOrDefaultAsync(ta => ta.Username == username && ta.Password == password);
        }

        private IActionResult GenerateTokenForUser(object user, string role)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                new Claim(ClaimTypes.Role, role),
            };

            if (role == "TravelAgent" && user is Agent travelAgent)
            {
                // Add the IsApproved claim for Travel Agents
                claims.Add(new Claim("IsApproved", travelAgent.IsApproved.ToString()));
            }


            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                claims,
                expires: DateTime.UtcNow.AddMinutes(60),
                signingCredentials: signIn);

            return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token),user });
        }
    }
}
