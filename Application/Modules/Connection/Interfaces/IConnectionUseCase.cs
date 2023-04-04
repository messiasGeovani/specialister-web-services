using Application.Modules.Connections.DTOs;
using Application.Modules.Profile.DTOs;

namespace Application.Modules.Profile.Interfaces
{
    public interface IConnectionUseCase
    {
        Task<ProfileDTO?> CreateConnection(Guid profileID, ConnectionDTO dto);
        Task<List<ConnectionDTO?>> GetConnections(Guid profileID);
    }
}
