using Application.Common.Interfaces;
using Application.Modules.Users.DTOs;
using Application.Modules.Users.Interfaces;
using Http.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using UserApi.Application.DTOs;
using UserApi.Application.Interfaces;

namespace UserApi.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : MainController
    {
        private IUserUseCase _userUseCase;
        private ITokenService _tokenService;

        public UserController(IUserUseCase userUseCase, ITokenService tokenService, IErrorNotifier errorNotifier)
            : base(errorNotifier)
        {
            _userUseCase = userUseCase;
            _tokenService = tokenService;
        }

        [HttpPost]
        public async Task<ActionResult<UserDTO>> CreateUser(UserDTO dto)
        {
            var user = await _userUseCase.CreateUser(dto);

            if (user is null)
            {
                return CustomResponse();
            }

            var token = _tokenService.GenerateToken(user);

            return CustomResponse(new
            {
                UserName = user.Username,
                Token = token
            });
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("usernames/{username}")]
        public async Task<ActionResult> CheckUserName([FromRoute] string username)
        {
            var userNameAlreadyExists = await _userUseCase.CheckIfUsernameExists(username);

            return CustomResponse(new
            {
                UsernameAlreadyExists = userNameAlreadyExists
            });
        }

        [HttpPatch]
        [Authorize]
        [Route("roles/{role}")]
        public async Task<ActionResult<AuthDTO>> SetUserRole([FromRoute] string role)
        {
            var userId = HttpContext.User.FindFirstValue("Id");
            var updatedUser = await _userUseCase.SetUserRole(role, new Guid(userId));

            if (updatedUser is null)
            {
                return CustomResponse();
            }

            var token = _tokenService.GenerateToken(updatedUser);

            return CustomResponse(new
            {
                UserName = updatedUser.Username,
                Role = updatedUser.Role,
                Token = token,
            });
        }
    }
}
