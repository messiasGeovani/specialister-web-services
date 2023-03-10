using Application.Common.DTOs;
using Application.Common.Interfaces;
using AutoMapper;
using Domain.Interfaces;
using UserApi.Application.Common.DTOs;
using UserApi.Application.Common.Interfaces;

namespace UserApi.Application.Common.Services
{
    public class AuthService : IAuthService
    {
        private IMapper _mapper;
        private IErrorNotifier _errorNotifier;
        private IUserRepository _userRepository;
        private ITokenService _tokenService;
        private IHashService _hashService;

        public AuthService(
            IMapper mapper,
            IErrorNotifier errorNotifier,
            IUserRepository userRepository,
            ITokenService tokenService,
            IHashService hashService            
        )
        {
            _mapper = mapper;
            _errorNotifier = errorNotifier;
            _userRepository = userRepository;
            _tokenService = tokenService;
            _hashService = hashService;
        }

        public async Task<AuthDTO?> Authenticate(string username, string password)
        {
            var users = await _userRepository.Get();

            var user = users?.FirstOrDefault(
                x => x.UserName == username && _hashService.Compare(password, x.Password) == true);

            if (user is null)
            {
                _errorNotifier.AddNotification("Usuário ou senha inválidos");
                return null;
            }

            var token = _tokenService.GenerateToken(_mapper.Map<UserDTO>(user));
            var dto = _mapper.Map<AuthDTO>(user);

            dto.Password = null;
            dto.Token = token;

            return dto;
        }
    }
}
