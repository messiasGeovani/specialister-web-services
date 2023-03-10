using Application.Configuration.AutoMapper;
using Domain.Entities;
using UserApi.Application.DTOs;

namespace UserApi.Application.Configuration.AutoMapper
{
    public class UserProfile : BaseProfile
    {
        public UserProfile() : base()
        {
            CreateMap<User, AuthDTO>().ReverseMap();
        }
    }
}
