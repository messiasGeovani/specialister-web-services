﻿using Application.Common.Interfaces;
using Http.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UserApi.Application.DTOs;
using UserApi.Application.Interfaces;

namespace UserApi.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : MainController
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService, IErrorNotifier errorNotifier)
            : base(errorNotifier)
        {
            _authService = authService;
        }

        [HttpPost]
        public async Task<ActionResult<AuthDTO>> Authenticate([FromBody] AuthDTO dto)
        {
            var auth = await _authService.Authenticate(dto);

            return CustomResponse(auth);
        }

        [HttpGet]
        [Route("anonymous")]
        [AllowAnonymous]
        public ActionResult<dynamic> Anonymous()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

            var random = new Random();
            var randomString = new string(Enumerable.Repeat(chars, 10)
                .Select(s => s[random.Next(s.Length)]).ToArray());

            return Ok(new
            {
                Username = "Guest_" + randomString,
                Password = ""
            });
        }
    }
}
