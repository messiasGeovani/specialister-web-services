using Application.DTOs;

namespace Application.Interfaces
{
    public interface IUserService
    {
        UserDTO GetUser(Guid id);
    }
}
