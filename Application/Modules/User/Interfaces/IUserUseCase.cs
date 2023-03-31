using Application.Modules.User.DTOs;

namespace Application.Modules.User.Interfaces
{
    public interface IProfileUseCase
    {
        Task<UserDTO?> GetUser(Guid id);
        Task<UserDTO?> CreateUser(UserDTO dto);
        Task<UserDTO?> SetUserRole(string role, Guid userId);
        Task<bool?> CheckIfUsernameExists(string username);
    }
}
