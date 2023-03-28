using Application.Configuration.AutoMapper;
using Domain.Entities;
using UserApi.Application.DTOs;

namespace UserApi.Infra.Configuration
{
    public class AutoMapper : MainProfile
    {
        public AutoMapper() : base()
        {
            CreateMap<User, AuthDTO>().ReverseMap();
        }
    }
}
