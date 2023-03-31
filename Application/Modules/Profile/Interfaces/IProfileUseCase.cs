using Application.Modules.Profile.DTOs;

namespace Application.Modules.Profile.Interfaces
{
    public interface IProfileUseCase
    {
        Task<ProfileDTO?> CreateProfile(ProfileDTO dto);
        Task<ProfileDTO?> GetProfile(Guid id);
        Task UpdateProfile(ProfileDTO dto);
    }
}
