using Application.Interfaces.PilotInterfaces;
using Communication.Responses.Pilot;

namespace Application.UseCase.Pilot
{
    public class GetByIdUseCase
    {
        private IPilotService _pilotService;

        public GetByIdUseCase(IPilotService pilotService)
        {
            _pilotService = pilotService;
        }

        public async Task<PilotResponse> Execute(Guid id)
        {
            return await _pilotService.GetPilotById(id);
        }
    }
}
