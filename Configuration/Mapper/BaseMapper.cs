using Application.Modules.Address.DTOs;
using Application.Modules.Person.DTOs;
using Application.Modules.User.DTOs;
using AutoMapper;
using Domain.Entities;

namespace Configuration.Mapper
{
    public class BaseMapper : Profile
    {
        public BaseMapper()
        {
            CreateMap<UserEntity, UserDTO>().ReverseMap();
            CreateMap<PersonEntity, PersonDTO>().ReverseMap();
            CreateMap<AddressEntity, AddressDTO>().ReverseMap();
        }
    }
}
