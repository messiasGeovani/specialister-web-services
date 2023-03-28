using UserApi.Application.DTOs;

namespace UserApi.Application.Interfaces
{
    public interface IAuthService
    {
        public Task<AuthDTO?> Authenticate(AuthDTO dto);
    }
}
