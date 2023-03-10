using Application.Common.DTOs;

namespace UserApi.Interfaces
{
    public interface ITokenService
    {
        string GenerateToken(UserDTO user);
        UserDTO DecryptToken(string token);
    }

    
}
