using Application.Configuration.AutoMapper;
using Domain.Entities;
using UserApi.Application.Common.DTOs;

namespace UserApi.Application.Configuration.AutoMapper
{
    public class UserProfile : MainProfile
    {
        public UserProfile() : base()
        {
            CreateMap<User, AuthDTO>().ReverseMap();
        }
    }
}
