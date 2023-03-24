using Application.Common.DTOs;
using Application.Common.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;


namespace Application.Common.UseCases
{
    public class UserUseCase : IUserUseCase
    {
        private IErrorNotifier _errorNotifier;
        private IUserRepository _userRepository;
        private IMapper _mapper;
        private IHashService _hashService;

        public UserUseCase(IErrorNotifier errorNotifier, IUserRepository userRepository, IMapper mapper, IHashService hashService)
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
                x => x.Username == dto.Username
            );

            if (users.Any())
            {
                _errorNotifier.AddNotification("Username already exists!");
                return null;
            }

            var user = new User()
            {
                Username = dto.Username,
                Password = _hashService.EncryptPassword(dto.Password),
            };

            await _userRepository.Create(user);

            user.Password = null;

            return _mapper.Map<UserDTO>(user);
        }

        public async Task<UserDTO?> SetUserRole(string role, Guid userId)
        {
            var isValidRole = role == "specialist" || role == "explorer";

            if (!isValidRole)
            {
                _errorNotifier.AddNotification("Invalid role!");
                return null;
            }

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

        public async Task<bool?> CheckIfUsernameExists(string username)
        {
            if (username is null)
            {
                _errorNotifier.AddNotification("Invalid username");
                return null;
            }

            var users = await _userRepository.Search(x => x.Username == username);

            if (users.Any())
            {
                return true;
            }

            return false;
        }
    }
}
