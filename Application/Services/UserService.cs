using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services
{
    public class UserService : IUserService
    {
        private IUserRepository _userRepository;
        private IMapper _mapper;
        private IHashService _hashService;
        public UserService(IUserRepository userRepository, IMapper mapper, IHashService hashService)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _hashService = hashService;
        }

        public async Task<UserDTO> GetUser(Guid id)
        {
            var user = await _userRepository.GetById(id);

            if (user is null)
            {
                return null;
            }

            return _mapper.Map<UserDTO>(user);
        }

        public async Task<UserDTO> CreateUser(UserDTO dto)
        {
            var hashPassword = _hashService.EncryptPassword(dto.Password);
            var user = new User()
            {
                UserName = dto.UserName,
                Password = hashPassword,
            };

            await _userRepository.Create(user);

            user.Password = null;

            return _mapper.Map<UserDTO>(user);
        }
    }
}
