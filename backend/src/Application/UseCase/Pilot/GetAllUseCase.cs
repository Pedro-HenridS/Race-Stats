using Application.Interfaces.PilotInterfaces;
using Communication.Responses.Pilot;

namespace Application.UseCase.Pilot
{
    public class GetAllUseCase
    {
        private IPilotService _pilotService;

        public GetAllUseCase(IPilotService pilotService)
        {
            _pilotService = pilotService;
        }

        public async Task<List<PilotResponse>> Execute()
        {
            return await _pilotService.GetAllPilotAsync();
        }
    }
}
