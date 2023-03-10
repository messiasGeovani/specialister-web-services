using UserApi.Application.Common.DTOs;

namespace UserApi.Application.Common.Interfaces
{
    public interface IAuthService
    {
        public Task<AuthDTO?> Authenticate(AuthDTO dto);
    }
}
