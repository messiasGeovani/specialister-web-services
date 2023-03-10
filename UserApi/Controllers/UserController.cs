using Application.Common.DTOs;
using Application.Common.Interfaces;
using Http.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using UserApi.Application.Common.DTOs;
using UserApi.Application.Common.Interfaces;

namespace UserApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseController
    {
        private IUserService _userService;
        private ITokenService _tokenService;

        public UserController(IUserService userService, ITokenService tokenService, IErrorNotifier errorNotifier)
            : base(errorNotifier)
        {
            _userService = userService;
            _tokenService = tokenService;
        }

        [HttpPost]
        public async Task<ActionResult<UserDTO>> CreateUser(UserDTO dto)
        {
            var user = await _userService.CreateUser(dto);

            return CustomResponse(user);
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
                return CustomResponse();
            }

            var token = _tokenService.GenerateToken(updatedUser);

            return CustomResponse(new AuthDTO()
            {
                UserName = updatedUser.UserName,
                Token = token,
            });
        }
    }
}
