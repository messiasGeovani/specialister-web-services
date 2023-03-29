using Application.Common.Interfaces;
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
        private readonly IMapper _mapper;
        private readonly IHashService _hashService;

        public PersonUseCase(IErrorNotifier errorNotifier, IPersonRepository personRepository, IMapper mapper, IHashService hashService)
        {
            _errorNotifier = errorNotifier;
            _personRepository = personRepository;
            _mapper = mapper;
            _hashService = hashService;
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

            await _personRepository.Create(person);

            return _mapper.Map<PersonDTO>(person);
        }

        public async Task<PersonDTO?> GetPerson(Guid id)
        {
            var person = await _personRepository.GetById(id);

            if (person is null)
            {
                _errorNotifier.AddNotification("Person does not exist!");
                return null;
            }

            return _mapper.Map<PersonDTO>(person);
        }

        public async Task UpdatePerson(Guid id, PersonDTO dto)
        {
            var person = await _personRepository.GetById(id);

            if (person is null)
            {
                _errorNotifier.AddNotification("User does not exist!");
            }
            else
            {
                await _personRepository.Update(_mapper.Map<PersonEntity>(dto));
            }
        }
    }
}
