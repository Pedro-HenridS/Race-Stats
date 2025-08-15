using Application.Interfaces.PilotInterfaces;
using Application.Mapping;
using Communication.Responses.Pilot;
using Domain.Interfaces.PilotRepository;
using Exception;

namespace Application.Services.Pilots
{
    public class PilotService : IPilotService
    {
        private readonly IPilotRepository _pilotRepository;
        private PilotMapping _pilotMapping;

        public PilotService(
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

            if (pilots is null) {
                throw new RaceException(ResourceErrorMessages.PILOTS_NOT_FOUND, 404);
            }

            var response = pilots.Select(register => _pilotMapping.MapToResponse(register)).ToList();
            
            return response;
        }

        public async Task<PilotResponse> GetPilotById(Guid id)
        {
            var pilot = await _pilotRepository.GetPilotById(id);

            if (pilot is null)
            {
                throw new RaceException(ResourceErrorMessages.PILOTS_NOT_FOUND, 404);
            }

            var response = _pilotMapping.MapToResponse(pilot);
                
            return response;
        }
    }
}
