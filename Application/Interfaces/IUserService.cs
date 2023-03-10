using Application.DTOs;

namespace Application.Interfaces
{
    public interface IUserService
    {
        Task<UserDTO> GetUser(Guid id);
        Task<UserDTO> CreateUser(UserDTO dto);
    }
}
