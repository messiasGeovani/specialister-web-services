using Application.Modules.User.DTOs;
using AutoMapper;
using Domain.Entities;

namespace Configuration.Mapper
{
    public class BaseMapper : Profile
    {
        public BaseMapper()
        {
            CreateMap<User, UserDTO>().ReverseMap();
        }
    }
}
