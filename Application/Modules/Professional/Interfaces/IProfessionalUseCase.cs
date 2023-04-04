using Application.Modules.Address.DTOs;
using Application.Modules.Professional.DTOs;

namespace Application.Modules.Professional.Interfaces
{
    public interface IProfessionalUseCase
    {
        Task<ProfessionalDTO?> GetProfessional(Guid id);
        Task<ProfessionalDTO?> CreateProfessional(ProfessionalDTO dto);
        Task UpdateProfessional(Guid id, ProfessionalDTO dto);
        Task<ProfessionalDTO?> UpdateCompanyAddress(Guid professionalID, AddressDTO addressDTO);
    }
}
