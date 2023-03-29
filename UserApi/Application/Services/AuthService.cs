using Application.Common.Interfaces;
using Application.Modules.User.DTOs;
using AutoMapper;
using Domain.Interfaces;
using UserApi.Application.DTOs;
using UserApi.Application.Interfaces;

namespace UserApi.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IMapper _mapper;
        private readonly IErrorNotifier _errorNotifier;
        private readonly IUserRepository _userRepository;
        private readonly ITokenService _tokenService;
        private readonly IHashService _hashService;

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

        public async Task<AuthDTO?> Authenticate(AuthDTO dto)
        {
            var users = await _userRepository.Search(
                x => x.Username == dto.UserName
            );

            if (users is null || !users.Any())
            {
                _errorNotifier.AddUnauthorizedNotification("Invalid user data!");
                return null;
            }

            var user = users.FirstOrDefault(x => _hashService.Compare(dto.Password, x.Password) == true);

            if (user is null)
            {
                _errorNotifier.AddUnauthorizedNotification("Invalid user data!");
                return null;
            }

            var token = _tokenService.GenerateToken(_mapper.Map<UserDTO>(user));
            var response = _mapper.Map<AuthDTO>(user);

            response.Password = null;
            response.Token = token;

            return response;
        }
    }
}
