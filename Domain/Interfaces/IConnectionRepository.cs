using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IConnectionRepository
    {
        Task<ProfileConnectionEntity> Create(ProfileConnectionEntity connection);
        Task<List<ProfileConnectionEntity>> GetByProfileID(Guid profileId);
    }
}
