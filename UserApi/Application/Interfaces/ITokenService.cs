using Application.Modules.Users.DTOs;

namespace UserApi.Application.Interfaces
{
    public interface ITokenService
    {
        string GenerateToken(UserDTO user);
        UserDTO DecryptToken(string token);
    }


}
