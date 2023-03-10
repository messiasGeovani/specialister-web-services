using Application.Common.DTOs;

namespace UserApi.Application.Common.Interfaces
{
    public interface ITokenService
    {
        string GenerateToken(UserDTO user);
        UserDTO DecryptToken(string token);
    }


}
