using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using Domain.Interfaces;

namespace Application.Services
{
    public class UserService : IUserService
    {
        private IUserRepository _userRepository;
        private IMapper _mapper;
        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserDTO> GetUser(Guid id)
        {
            var user = await _userRepository.FindById(id);

            if (user == null)
            {
                return null;
            }

            return _mapper.Map<UserDTO>(user);
        }
    }
}
