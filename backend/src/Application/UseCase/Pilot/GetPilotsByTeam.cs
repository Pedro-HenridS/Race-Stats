using Application.Interfaces.PilotInterfaces;
using Domain.Interfaces.PilotRepository;

namespace Application.UseCase.Pilot
{
    public class GetPilotsByTeam
    {
        private IPilotGetService _pilotService;

        public GetPilotsByTeam(IPilotGetService pilotService)
        {
            _pilotService = pilotService;
        }

        public async Task<List<TeamPilotsRepository>> Execute()
        {

            var response = await _pilotService.GetPilotsByTeamsAsync();

            return response;
        }
    }
}
