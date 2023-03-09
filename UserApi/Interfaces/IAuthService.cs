using Application.DTOs;

namespace UserApi.Interfaces
{
    public interface IAuthService
    {
        public UserDTO? Authenticate(string username, string password);
    }
}
