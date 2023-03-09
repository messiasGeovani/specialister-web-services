using UserApi.Application.DTOs;

namespace UserApi.Application.Interfaces
{
    public interface IAuthService
    {
        public Task<AuthDTO?> Authenticate(string username, string password);
    }
}
