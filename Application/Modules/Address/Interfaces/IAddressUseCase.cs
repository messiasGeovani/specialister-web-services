using Application.Modules.Address.DTOs;

namespace Application.Modules.Address.Interfaces
{
    public interface IAddressUseCase
    {
        Task<AddressDTO?> GetAddress(Guid id);
        Task<AddressDTO?> CreateAddress(AddressDTO addressDTO);
        Task<AddressDTO?> UpdateAddress(Guid id, AddressDTO addressDTO);
    }
}
