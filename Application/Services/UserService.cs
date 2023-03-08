using Application.DTOs;
using Application.Interfaces;

namespace Application.Services
{
    public class UserService : IUserService
    {
        public IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public UserDTO GetUser(int id)
        {
            return new UserDTO()
            {
                Users = _userRepository.FindById(id)
            };
        }
    }
}
