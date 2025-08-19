using Application.Interfaces.PilotInterfaces;
using Domain.Dto.TeamsDto;

namespace Application.UseCase.Pilot
{
    public class GetPilotsByTeam
    {
        private IPilotGetService _pilotService;

        public GetPilotsByTeam(IPilotGetService pilotService)
        {
            _pilotService = pilotService;
        }

        public async Task<List<TeamPilotsDto>> Execute(string category)
        {

            var response = await _pilotService.GetPilotsByTeamsAsync(category);

            return response;
        }
    }
}
