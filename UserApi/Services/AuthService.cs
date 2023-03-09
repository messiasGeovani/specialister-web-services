using Application.DTOs;
using Application.Interfaces;
using Domain.Interfaces;
using UserApi.Interfaces;

namespace UserApi.Services
{
    public class AuthService : IAuthService
    {
        private IUserRepository _userRepository;
        private ITokenService _tokenService;
        private IHashService _hashService;

        public AuthService(IUserRepository userRepository, ITokenService tokenService, IHashService hashService)
        {
            _userRepository = userRepository;
            _tokenService = tokenService;
            _hashService = hashService;
        }

        public UserDTO? Authenticate(string username, string password)
        {
            var hashPassword = _hashService.EncryptPassword(password);
            var user = _userRepository.Find(username, hashPassword);

            if (user == null)
            {
                return null;
            }

            var token = _tokenService.GenerateToken(user);

            return new UserDTO
            {
                Id = user.Id,
                UserName = username,
                Token = token,
            };
        }
    }
}
