using Application.Common.Interfaces;
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
        private readonly IErrorNotifier _errorNotifier;
        private readonly IMapper _mapper;

        public ProfessionalUseCase(IProfessionalRepository professionalRepository, IErrorNotifier errorNotifier, IMapper mapper)
        {
            _professionalRepository = professionalRepository;
            _errorNotifier = errorNotifier;
            _mapper = mapper;
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
                _errorNotifier.AddNotification("Professional does not exist!");
            }
            else
            {
                await _professionalRepository.Update(_mapper.Map<ProfessionalEntity>(dto));
            }
        }
    }
}
