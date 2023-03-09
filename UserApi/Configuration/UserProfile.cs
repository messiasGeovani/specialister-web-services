using Configuration;
using Domain.Entities;
using UserApi.Application.DTOs;

namespace UserApi.Configuration
{
    public class UserProfile : BaseProfile
    {
        public UserProfile() : base()
        {
            CreateMap<User, AuthDTO>().ReverseMap();
        }
    }
}
