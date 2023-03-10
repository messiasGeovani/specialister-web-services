using Application.Common.DTOs;
using AutoMapper;
using Domain.Entities;

namespace Application.Configuration.AutoMapper
{
    public class BaseProfile : Profile
    {
        public BaseProfile()
        {
            CreateMap<User, UserDTO>().ReverseMap();
        }
    }
}
