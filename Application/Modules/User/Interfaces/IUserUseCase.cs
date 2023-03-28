using Application.Modules.Users.DTOs;

namespace Application.Modules.Users.Interfaces
{
    public interface IUserUseCase
    {
        Task<UserDTO?> GetUser(Guid id);
        Task<UserDTO?> CreateUser(UserDTO dto);
        Task<UserDTO?> SetUserRole(string role, Guid userId);
        Task<bool?> CheckIfUsernameExists(string username);
    }
}
