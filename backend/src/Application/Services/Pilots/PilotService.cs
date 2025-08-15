using Application.Interfaces.PilotInterfaces;
using Communication.Enums;
using Communication.Responses.Pilot;
using Domain.Interfaces.PilotRepository;
using Exception;

namespace Application.Services.Pilots
{
    public class PilotService : IPilotService
    {
        private readonly IPilotRepository _pilotRepository;

        public PilotService(IPilotRepository pilotRepository)
        {
            _pilotRepository = pilotRepository;
        }

        public async Task<List<PilotResponse>> GetAllPilotAsync()
        {
            var registros = await _pilotRepository.GetPilots();

            if (registros == null) {
                throw new RaceException(ResourceErrorMessages.PILOTS_NOT_FOUND, 204);
            }

            var response = registros.Select(register =>
                    new PilotResponse
                    {
                        Name  = register.Name,
                        Fastestlap = register.Fastestlap,
                        Weight  = register.Weight,
                        Gender = (Gender)register.Gender,
                        Nationality = register.Nationality,
                        Circuit = register.Circuit,
                        TeamId = register.TeamId,
                        Category = (SingleSeaterCategory)register.Category
                    }
                ).ToList();
            
            return response;
        }
    }
}
