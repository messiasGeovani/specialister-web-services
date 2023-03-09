using Application.DTOs;
using Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using UserApi.Interfaces;
using UserApi.Services;

namespace UserApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        [Route("auth")]
        public ActionResult<UserDTO> AuthenticateAsync([FromBody] UserDTO model)
        {
            var auth = _authService.Authenticate(model.UserName, model.Password);

            if (auth == null)
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
