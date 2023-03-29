using Application.Common.Interfaces;
using Application.Modules.Address.DTOs;
using Application.Modules.Address.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Modules.Address.UseCases
{
    public class AddressUseCase : IAddressUseCase
    {
        private readonly IAddressRepository _addressRepository;
        private readonly IErrorNotifier _errorNotifier;
        private readonly IMapper _mapper;

        public AddressUseCase(IAddressRepository addressRepository, IErrorNotifier errorNotifier, IMapper mapper)
        {
            _addressRepository = addressRepository;
            _errorNotifier = errorNotifier;
            _mapper = mapper;
        }

        public async Task<AddressDTO?> CreateAddress(AddressDTO addressDTO)
        {
            var address = new AddressEntity()
            {
                City = addressDTO.City,
                Country = addressDTO.Country,
                Number = addressDTO.Number,
                PostalCode = addressDTO.PostalCode,
                State = addressDTO.State,
                Street = addressDTO.Street,
            };

            await _addressRepository.Create(address);

            return _mapper.Map<AddressDTO>(address);
        }

        public async Task<AddressDTO?> GetAddress(Guid id)
        {
            var address = await _addressRepository.GetById(id);

            return _mapper.Map<AddressDTO?>(address);
        }

        public async Task<AddressDTO?> UpdateAddress(Guid id, AddressDTO addressDTO)
        {
            var address = await _addressRepository.GetById(id);

            if (address is null)
            {
                _errorNotifier.AddNotification("Address does not exist!");
                return null;
            }

            await _addressRepository.Update(_mapper.Map<AddressEntity>(addressDTO));

            return addressDTO;
        }
    }
}
