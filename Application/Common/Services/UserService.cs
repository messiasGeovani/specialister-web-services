using Application.Common.DTOs;
using Application.Common.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;


namespace Application.Common.Services
{
    public class UserService : IUserService
    {
        private IErrorNotifier _errorNotifier;
        private IUserRepository _userRepository;
        private IMapper _mapper;
        private IHashService _hashService;

        public UserService(IErrorNotifier errorNotifier, IUserRepository userRepository, IMapper mapper, IHashService hashService)
        {
            _errorNotifier = errorNotifier;
            _userRepository = userRepository;
            _mapper = mapper;
            _hashService = hashService;
        }

        public async Task<UserDTO?> GetUser(Guid id)
        {
            var user = await _userRepository.GetById(id);

            if (user is null)
            {
                _errorNotifier.AddNotification("User does not exist!");
                return null;
            }

            return _mapper.Map<UserDTO>(user);
        }

        public async Task<UserDTO?> CreateUser(UserDTO dto)
        {
            var users = await _userRepository.Search(
                x => x.UserName == dto.UserName
            );

            if (users != null)
            {
                _errorNotifier.AddNotification("Username already exists!");
                return null;
            }

            var user = new User()
            {
                UserName = dto.UserName,
                Password = dto.Password,
            };

            await _userRepository.Create(user);

            user.Password = null;

            return _mapper.Map<UserDTO>(user);
        }

        public async Task<UserDTO?> SetUserRole(string role, Guid userId)
        {
            var user = await _userRepository.GetById(userId);

            if (user is null)
            {
                _errorNotifier.AddNotification("User does not exist!");
                return null;
            }

            if (user.Role != null)
            {
                _errorNotifier.AddNotification("User already have a role!");
                return null;
            }

            user.Role = role;

            await _userRepository.Update(user);

            return _mapper.Map<UserDTO>(user);
        }
    }
}
