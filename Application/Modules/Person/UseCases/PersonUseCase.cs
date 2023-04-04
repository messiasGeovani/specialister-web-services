using Application.Common.Interfaces;
using Application.Modules.Address.DTOs;
using Application.Modules.Person.DTOs;
using Application.Modules.Person.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Modules.Person.UseCases
{
    public class PersonUseCase : IPersonUseCase
    {
        private readonly IErrorNotifier _errorNotifier;
        private readonly IPersonRepository _personRepository;
        private readonly IAddressRepository _addressRepository;
        private readonly IMapper _mapper;

        public PersonUseCase(IErrorNotifier errorNotifier, IPersonRepository personRepository, IMapper mapper, IAddressRepository addressRepository)
        {
            _errorNotifier = errorNotifier;
            _personRepository = personRepository;
            _mapper = mapper;
            _addressRepository = addressRepository;
        }

        public async Task<PersonDTO?> CreatePerson(PersonDTO dto)
        {
            var person = new PersonEntity()
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
            };

            if (dto.Document != null)
            {
                person.DocumentNumber = dto.Document;
            }

            if (dto.Address != null)
            {
                var personAddress = _mapper.Map<AddressEntity>(dto.Address);
                person.Address = personAddress;
            }

            await _personRepository.Create(person);

            return _mapper.Map<PersonDTO>(person);
        }

        public async Task<PersonDTO?> GetPerson(Guid id)
        {
            var person = await _personRepository.GetById(id);

            if (person is null)
            {
                _errorNotifier.AddNotFoundNotification("Person Data Not Found");
                return null;
            }

            return _mapper.Map<PersonDTO>(person);
        }

        public async Task UpdatePerson(Guid id, PersonDTO dto)
        {
            var person = await _personRepository.GetById(id);

            if (person is null)
            {
                _errorNotifier.AddNotification("Person does not exist!");
            }
            else
            {
                await _personRepository.Update(_mapper.Map<PersonEntity>(dto));
            }
        }

        public async Task<PersonDTO?> UpdatePersonAddress(Guid personID, AddressDTO addressDTO)
        {
            var person = await _personRepository.GetById(personID);

            if (person is null)
            {
                _errorNotifier.AddNotification("Invalid person id!");
                return null;
            }

            if (person.AddressId == Guid.Empty)
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

                person.AddressId = address.Id;
                person.Address = address;
            }
            else
            {
                person.Address = _mapper.Map<AddressEntity>(addressDTO);
            }

            await _personRepository.Update(person);

            return _mapper.Map<PersonDTO>(person);
        }
    }
}
