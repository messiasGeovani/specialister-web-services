using Application.DTOs;
using Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using UserApi.Application.DTOs;
using UserApi.Application.Interfaces;
using UserApi.Services;

namespace UserApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IAuthService _authService;
        private IHashService _hashService;

        public AuthController(IAuthService authService, IHashService hashService)
        {
            _authService = authService;
            _hashService = hashService;
        }

        [HttpPost]
        [Route("auth")]
        public async Task<ActionResult<AuthDTO>> Authenticate([FromBody] AuthDTO model)
        {
            var auth = await _authService.Authenticate(model.UserName, model.Password);

            if (auth is null)
            {
                return BadRequest(new { message = "Usuário ou senha inválida" });
            }

            return auth;
        }

        [HttpGet]
        [Route("anonymous")]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> Anonymous()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

            var random = new Random();
            var randomString = new string(Enumerable.Repeat(chars, 10)
                .Select(s => s[random.Next(s.Length)]).ToArray());

            return Ok(new
            {
                Username = "Guest_" + randomString,
                Password = _hashService.EncryptPassword("seila123")
            });
        }

        [HttpGet]
        [Route("employees")]
        [Authorize(Roles = "employee,manager")]
        public async Task<ActionResult> Employee() => NoContent();

        [HttpGet]
        [Route("managers")]
        [Authorize(Roles = "manager")]
        public async Task<ActionResult> Manager() => NoContent();
    }
}
