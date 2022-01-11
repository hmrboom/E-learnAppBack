﻿
using LicentaB.Models;
using LicentaB.Payloads;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using BC = BCrypt.Net.BCrypt;
namespace LicentaB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly dbLicentaContext _db;
        private readonly ILogger<UserController> _logger;
        private IConfiguration _config { get; }

        public UserController(dbLicentaContext db, ILogger<UserController> logger, IConfiguration configuration)
        {
            _db = db;
            _logger = logger;
            _config = configuration;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterPayload registerPayload)
        {
            try
            {
                var existingUser = _db.AspNetUsers
                    .Any(u => u.Email == registerPayload.Email);
                if (existingUser)
                {
                    return Ok(new { status = false, message = "inca un cont la fel" });
                }
                var userToCreate = new AspNetUser
                {
                    Id = Guid.NewGuid(),
                    LastName = registerPayload.Last_Name,
                    FirstName = registerPayload.First_Name,
                    Email = registerPayload.Email,
                    PasswordHash = BC.HashPassword(registerPayload.Password),
                    Gender = registerPayload.Gender

                };
                _db.AspNetUsers.Add(userToCreate);

                _db.SaveChanges();
                return Ok(new { status = true, message = " mere ba" });
            }
            catch (Exception e)
            {

                return new JsonResult(new { eroare = e.Message });
            }
        }
        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginPayload loginPayload)
        {
            var foundUser = _db.AspNetUsers
                .SingleOrDefault(u => u.Email == loginPayload.Email);
            if (foundUser != null)
            {
                if (BC.Verify(loginPayload.Password, foundUser.PasswordHash))
                {
                    string tokenString = GenerateJSONWebToken(foundUser);
                    return Ok(new { status = true, token = tokenString });
                }
                return BadRequest(new { status = false, message = "NU mere pass sau nume" });
            }

            else
            {
                return BadRequest(new { status = false, message = "NU mere" });
            }
        }
        private string GenerateJSONWebToken(AspNetUser user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                new Claim("Id",user.Id.ToString())
            };
            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Issuer"],
              claims,
              expires: DateTime.Now.AddDays(10),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }




    }
}