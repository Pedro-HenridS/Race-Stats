using Application.Interfaces.PilotInterfaces;
using Communication.Responses.Pilot;

namespace Application.UseCase.Pilot
{
    public class GetByIdUseCase
    {
        private IPilotGetService _pilotService;

        public GetByIdUseCase(IPilotGetService pilotService)
        {
            _pilotService = pilotService;
        }

        public async Task<PilotResponse> Execute(Guid id)
        {
            return await _pilotService.GetPilotByIdAsync(id);
        }
    }
}
