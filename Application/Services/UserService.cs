using Application.DTOs;
using Application.Interfaces;
using Domain.Interfaces;

namespace Application.Services
{
    public class UserService : IUserService
    {
        private IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public UserDTO? GetUser(Guid id)
        {
            var user = _userRepository.FindById(id);

            if (user == null)
            {
                return null;
            }

            return new UserDTO()
            {
                Id = user.Id,
                UserName = user.UserName
            };
        }
    }
}
