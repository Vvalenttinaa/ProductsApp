using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.EntityFrameworkCore;
using MyApp.Models.DTOs;
using MyApp.Models.Entities;
using MyApp.Services;
using MyApp.Models.Requests;

namespace   MyApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class AuthController : ControllerBase
    {

        private readonly AuthService _service;

        public AuthController(AuthService service)
        {
            _service = service;
        }


        [HttpPost("register")]
        public async Task<ActionResult<User>> Register(RegisterRequest registerRequest)
        {
            try
            {
                var userDTO = await _service.Register(registerRequest);
                return CreatedAtAction(nameof(GetUser), new { id = userDTO.Id }, userDTO);
            }
            catch (DbUpdateException ex)
            {
                return Conflict("User with given e-mail already exists!");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An unexpected error occurred.");
            }
        }

        [HttpPost("login")]
        public async Task<ActionResult<string>> Login(LoginRequest loginRequest)
        {
            var token = await _service.Login(loginRequest);
            if (token == "User with given e-mail does not exist!")
            {
                return NotFound(token);
            }

            if (token == "Wrong password!")
            {
                return BadRequest(token);
            }
            return Ok(token);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> GetUser(int id)
        {
            return (await _service.GetUser(id)) is var user ? Ok(user) : NotFound();
        }

    }
}
