using Application.Common.DTOs;

namespace Application.Common.Interfaces
{
    public interface IUserUseCase
    {
        Task<UserDTO?> GetUser(Guid id);
        Task<UserDTO?> CreateUser(UserDTO dto);
        Task<UserDTO?> SetUserRole(string role, Guid userId);
        Task<bool?> CheckIfUsernameExists(string username);
    }
}
