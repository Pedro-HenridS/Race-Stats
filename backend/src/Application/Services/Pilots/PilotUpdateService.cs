using Application.Interfaces.PilotInterfaces;
using Application.Mapping;
using Communication.Requests.Pilot;
using Domain.Enums;
using Domain.Interfaces.PilotRepository;
using Exception;

namespace Application.Services.Pilots
{
    public class PilotUpdateService : IPilotUpdateService
    {
        private readonly IPilotRepository _pilotRepository;

        public PilotUpdateService(
            IPilotRepository pilotRepository
            )
        {
            _pilotRepository = pilotRepository;
        }


        public async Task UpdatePilotAsync(Guid id, PutRecordRequest request)
        {
            var pilot = await _pilotRepository.GetPilotById(id);

            if (pilot is null)
            {
                throw new RaceException(ResourceErrorMessages.PILOTS_NOT_FOUND, 404);
            }

            pilot.Fastestlap = request.Fastestlap;
            pilot.Circuit = request.Circuit;
            pilot.Category = (SingleSeaterCategory)request.Category;

            await _pilotRepository.UpdatePilot(pilot);
        }
    }
}
