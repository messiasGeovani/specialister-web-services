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
        private readonly IPersonRepository _personRepository;
        private readonly IErrorNotifier _errorNotifier;
        private readonly IMapper _mapper;

        public AddressUseCase(IAddressRepository addressRepository, IErrorNotifier errorNotifier, IMapper mapper, IPersonRepository personRepository)
        {
            _addressRepository = addressRepository;
            _errorNotifier = errorNotifier;
            _mapper = mapper;
            _personRepository = personRepository;
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

            if (address is null)
            {
                _errorNotifier.AddNotFoundNotification("Address Data Not Found");
                return null;
            }

            return _mapper.Map<AddressDTO>(address);
        }
    }
}
