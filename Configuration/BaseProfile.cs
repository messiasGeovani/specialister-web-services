using Application.DTOs;
using AutoMapper;
using Domain.Entities;

namespace Configuration
{
    public class BaseProfile : Profile
    {
        public BaseProfile()
        {
            CreateMap<User, UserDTO>().ReverseMap();
        }
    }
}
