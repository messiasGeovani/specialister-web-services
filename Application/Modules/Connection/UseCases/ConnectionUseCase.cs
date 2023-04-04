using Application.Common.Interfaces;
using Application.Modules.Connections.DTOs;
using Application.Modules.Profile.DTOs;
using Application.Modules.Profile.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Modules.Connection.UseCases
{
    public class ConnectionUseCase : IConnectionUseCase
    {
        private readonly IConnectionRepository _connectionRepository;
        private readonly IProfileRepository _profileRepository;
        private readonly IErrorNotifier _errorNotifier;
        private readonly IMapper _mapper;

        public ConnectionUseCase(IConnectionRepository connectionRepository, IErrorNotifier errorNotifier, IMapper mapper, IProfileRepository profileRepository)
        {
            _connectionRepository = connectionRepository;
            _errorNotifier = errorNotifier;
            _mapper = mapper;
            _profileRepository = profileRepository;
        }

        public async Task<ProfileDTO?> CreateConnection(Guid profileID, ConnectionDTO dto)
        {
            var validProfile = await _profileRepository.GetById(profileID);

            if (validProfile is null)
            {
                _errorNotifier.AddNotification("Invalid Profile ID!");
                return null;
            }

            var validConnectionProfile = await _profileRepository.GetById(dto.Profile.Id);

            if (validConnectionProfile is null)
            {
                _errorNotifier.AddNotification("Invalid referenced profile!");
                return null;
            }

            var connection = new ProfileConnectionEntity()
            {
                Profile = validConnectionProfile,
                ProfileId = profileID,
            };

            await _connectionRepository.Create(connection);

            validProfile.Connections.Add(connection);

            await _profileRepository.Update(validProfile);

            return _mapper.Map<ProfileDTO>(validProfile);
        }

        public async Task<List<ConnectionDTO?>> GetConnections(Guid profileID)
        {
            var validProfile = await _profileRepository.GetById(profileID);

            if (validProfile is null)
            {
                _errorNotifier.AddNotification("Invalid profile id!");
                return null;
            }

            var connections = await _connectionRepository.GetByProfileID(profileID);

            return _mapper.Map<List<ConnectionDTO?>>(connections);
        }
    }
}
