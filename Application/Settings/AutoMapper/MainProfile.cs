using Application.Modules.Users.DTOs;
using AutoMapper;
using Domain.Entities;

namespace Application.Configuration.AutoMapper
{
    public class MainProfile : Profile
    {
        public MainProfile()
        {
            CreateMap<User, UserDTO>().ReverseMap();
        }
    }
}
