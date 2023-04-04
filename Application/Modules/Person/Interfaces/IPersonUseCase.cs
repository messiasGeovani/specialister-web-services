using Application.Modules.Address.DTOs;
using Application.Modules.Person.DTOs;

namespace Application.Modules.Person.Interfaces
{
    public interface IPersonUseCase
    {
        Task<PersonDTO?> GetPerson(Guid id);
        Task<PersonDTO?> CreatePerson(PersonDTO dto);
        Task UpdatePerson(Guid id, PersonDTO dto);
        Task<PersonDTO?> UpdatePersonAddress(Guid personID, AddressDTO addressDTO);
    }
}
