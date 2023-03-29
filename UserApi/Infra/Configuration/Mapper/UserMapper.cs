using Configuration.Mapper;
using Domain.Entities;
using UserApi.Application.DTOs;

namespace UserApi.Infra.Configuration.Mapper
{
    public class AutoMapper : BaseMapper
    {
        public AutoMapper() : base()
        {
            CreateMap<UserEntity, AuthDTO>().ReverseMap();
        }
    }
}
