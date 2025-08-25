using Application.Interfaces.PilotInterfaces;
using Communication.Requests.Pilot;
using Domain.Dto.PilotsDto;
using Domain.Enums;
using Domain.Interfaces.PilotRepository;

namespace Application.Services.Pilots
{
    public class PilotPostService : IPilotPostService
    {
        private readonly IPilotRepository _pilotRepository;

        public PilotPostService(IPilotRepository pilotRepository)
        {
            _pilotRepository = pilotRepository;
        }

        public async Task CreatePilot(PostPilotRequest request)
        {
            var pilot = new PilotRequest
            {
                Name = request.Name,
                Fastestlap = request.Fastestlap,
                Weight = request.Weight,
                Gender = Enum.Parse<Gender>(request.Gender.ToString()),
                Nationality = request.Nationality,
                Circuit = request.Circuit,
                TeamId = request.TeamId,
                Leader = request.Leader,
                Category = Enum.Parse<SingleSeaterCategory>(request.Category.ToString())
            };

            await _pilotRepository.CreatePilot(pilot);
        }
    }
}
