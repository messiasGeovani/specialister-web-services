using Application.Common.Interfaces;
using Application.Modules.Address.DTOs;
using Application.Modules.Professional.DTOs;
using Application.Modules.Professional.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Modules.Professional.UseCases
{
    public class ProfessionalUseCase : IProfessionalUseCase
    {
        private readonly IProfessionalRepository _professionalRepository;
        private readonly IAddressRepository _addressRepository;
        private readonly IErrorNotifier _errorNotifier;
        private readonly IMapper _mapper;

        public ProfessionalUseCase(IProfessionalRepository professionalRepository, IErrorNotifier errorNotifier, IMapper mapper, IAddressRepository addressRepository)
        {
            _professionalRepository = professionalRepository;
            _errorNotifier = errorNotifier;
            _mapper = mapper;
            _addressRepository = addressRepository;
        }

        public async Task<ProfessionalDTO?> CreateProfessional(ProfessionalDTO dto)
        {
            var professional = new ProfessionalEntity()
            {
                CompanyName = dto.CompanyName,
                Position = dto.Position,
            };

            if (dto.CompanyAddress != null)
            {
                var professionalCompanyAddress = _mapper.Map<AddressEntity>(dto.CompanyAddress);
                professional.CompanyAddress = professionalCompanyAddress;
            }

            await _professionalRepository.Create(professional);

            return _mapper.Map<ProfessionalDTO>(professional);
        }

        public async Task<ProfessionalDTO?> GetProfessional(Guid id)
        {
            var professional = await _professionalRepository.GetById(id);

            if (professional is null)
            {
                _errorNotifier.AddNotFoundNotification("Professional Data Not Found");
                return null;
            }

            return _mapper.Map<ProfessionalDTO>(professional);
        }

        public async Task UpdateProfessional(Guid id, ProfessionalDTO dto)
        {
            var professional = await _professionalRepository.GetById(id);

            if (professional is null)
            {
                _errorNotifier.AddNotification("Invalid professional id!");
            }
            else
            {
                await _professionalRepository.Update(_mapper.Map<ProfessionalEntity>(dto));
            }
        }

        public async Task<ProfessionalDTO?> UpdateCompanyAddress(Guid professionalID, AddressDTO addressDTO)
        {
            var professional = await _professionalRepository.GetById(professionalID);

            if (professional is null)
            {
                _errorNotifier.AddNotification("Invalid professional id!");
                return null;
            }

            if (professional.AddressId == Guid.Empty)
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

                professional.AddressId = address.Id;
                professional.CompanyAddress = address;
            }
            else
            {
                professional.CompanyAddress = _mapper.Map<AddressEntity>(addressDTO);
            }

            await _professionalRepository.Update(professional);

            return _mapper.Map<ProfessionalDTO>(professional);
        }
    }
}
