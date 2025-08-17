using Application.Interfaces.PilotInterfaces;
using Application.Mapping;
using Communication.Responses.Pilot;
using Domain.Interfaces.PilotRepository;
using Exception;

namespace Application.Services.Pilots
{
    public class PilotGetService : IPilotGetService
    {
        private readonly IPilotRepository _pilotRepository;
        private PilotMapping _pilotMapping;

        public PilotGetService(
            IPilotRepository pilotRepository,
            PilotMapping pilotMapping
            )
        {
            _pilotRepository = pilotRepository;
            _pilotMapping = pilotMapping;
        }

        public async Task<List<PilotResponse>> GetAllPilotAsync()
        {
            var pilots = await _pilotRepository.GetPilots();

            if (pilots is null)
            {
                throw new RaceException(ResourceErrorMessages.PILOTS_NOT_FOUND, 404);
            }

            var response = pilots.Select(register => _pilotMapping.MapToResponse(register)).ToList();

            return response;
        }

        public async Task<PilotResponse> GetPilotByIdAsync(Guid id)
        {
            var pilot = await _pilotRepository.GetPilotById(id);

            if (pilot is null)
            {
                throw new RaceException(ResourceErrorMessages.PILOTS_NOT_FOUND, 404);
            }

            var response = _pilotMapping.MapToResponse(pilot);

            return response;
        }

        public async Task<List<TeamPilotsRepository>> GetPilotsByTeamsAsync()
        {
            var response = await _pilotRepository.GetPilotsGroupByEquip();

            if (response is null)
            {
                throw new RaceException(ResourceErrorMessages.PILOTS_NOT_FOUND, 404);
            }

            return response;
        }
    }
}
