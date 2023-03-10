using Application.DTOs;
using Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using UserApi.Application.DTOs;
using UserApi.Interfaces;

namespace UserApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _userService;
        private ITokenService _tokenService;

        public UserController(IUserService userService, ITokenService tokenService)
        {
            _userService = userService;
            _tokenService = tokenService;
        }

        [HttpPost]
        public async Task<UserDTO> CreateUser(UserDTO dto)
        {
            var user = await _userService.CreateUser(dto);

            return user;
        }

        [HttpPatch]
        [Authorize]
        [Route("roles/specialist")]
        public async Task<ActionResult<AuthDTO>> SetUSerRole()
        {
            const string ROLE = "specialist";

            var userId = HttpContext.User.FindFirstValue("Id");

            if (userId is null) { 
                return Unauthorized();
            }

            var updatedUser = await _userService.SetUserRole(ROLE, new Guid(userId));

            if (updatedUser is null)
            {
                return Forbid();
            }

            var token = _tokenService.GenerateToken(updatedUser);

            return new AuthDTO()
            {
                UserName = updatedUser.UserName,
                Token = token,
            };
        }
    }
}
