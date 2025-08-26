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
            // Verifica se o piloto já existe.
            bool searchPilot = await _pilotService.PilotExistsAsync(request.Name);

            if (searchPilot)
            {
                // Lança exceção se o piloto já existe.
                throw new RaceException(ResourceErrorMessages.PILOT_ALREADY_EXIST, 409);
            }

            // Cria o novo piloto.
            await _pilotPostService.CreatePilot(request);
        }
    }
}
