﻿using Application.Common.Interfaces;
using Http.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UserApi.Application.Common.DTOs;
using UserApi.Application.Common.Interfaces;

namespace UserApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : BaseController
    {
        private IAuthService _authService;
        private IHashService _hashService;

        public AuthController(IAuthService authService, IHashService hashService, IErrorNotifier errorNotifier)
            : base(errorNotifier)
        {
            _authService = authService;
            _hashService = hashService;
        }

        [HttpPost]
        [Route("auth")]
        public async Task<ActionResult<AuthDTO>> Authenticate([FromBody] AuthDTO model)
        {
            var auth = await _authService.Authenticate(model.UserName, model.Password);

            return CustomResponse(auth);
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
        [Route("specialists")]
        [Authorize(Roles = "specialist")]
        public async Task<ActionResult> Specialist() => NoContent();

        [HttpGet]
        [Route("explorers")]
        [Authorize(Roles = "explorer")]
        public async Task<ActionResult> Explorer() => NoContent();
    }
}
