using Application.Interfaces;
using AutoMapper;
using Domain.Interfaces;
using UserApi.Application.DTOs;
using UserApi.Application.Interfaces;
using UserApi.Interfaces;

namespace UserApi.Application.Services
{
    public class AuthService : IAuthService
    {
        private IUserRepository _userRepository;
        private ITokenService _tokenService;
        private IHashService _hashService;
        private IMapper _mapper;

        public AuthService(
            IUserRepository userRepository,
            ITokenService tokenService,
            IHashService hashService,
            IMapper mapper
        )
        {
            _userRepository = userRepository;
            _tokenService = tokenService;
            _hashService = hashService;
            _mapper = mapper;
        }

        public async Task<AuthDTO?> Authenticate(string username, string password)
        {
            var hashPassword = _hashService.EncryptPassword(password);
            var user = await _userRepository.Find(username, hashPassword);

            if (user == null)
            {
                return null;
            }

            var token = _tokenService.GenerateToken(user);
            var dto = _mapper.Map<AuthDTO>(user);

            dto.Token = token;

            return dto;
        }
    }
}
