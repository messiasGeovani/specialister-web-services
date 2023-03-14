using Application.Common.DTOs;

namespace Application.Common.Interfaces
{
    public interface IUserService
    {
        Task<UserDTO?> GetUser(Guid id);
        Task<UserDTO?> CreateUser(UserDTO dto);
        Task<UserDTO?> SetUserRole(string role, Guid userId);
    }
}
