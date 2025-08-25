using Application.Interfaces.PilotInterfaces;
using Communication.Requests.Pilot;
using Exception;

namespace Application.UseCase.Pilot
{
    public class AddPilotUseCase
    {

        private IPilotGetService _pilotService;
        private IPilotPostService _pilotPostService;

        public AddPilotUseCase(IPilotGetService pilotService, IPilotPostService pilotPostService)
        {
            _pilotService = pilotService;
            _pilotPostService = pilotPostService;
        }

        public async Task Execute(PostPilotRequest request)
        {
            bool searchPilot = await _pilotService.PilotExistsAsync(request.Name);

            if (searchPilot)
            {
                throw new RaceException(ResourceErrorMessages.PILOT_ALREADY_EXIST, 409);
            }

            await _pilotPostService.CreatePilot(request);
        }
    }
}
