using Application.DTOs;
using Domain.Entities;

namespace UserApi.Interfaces
{
    public interface ITokenService
    {
        string GenerateToken(UserDTO user);
        UserDTO DecryptToken(string token);
    }

    
}
