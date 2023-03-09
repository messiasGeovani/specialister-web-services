using Domain.Entities;

namespace UserApi.Interfaces
{
    public interface ITokenService
    {
        string GenerateToken(User user);
    }
}
