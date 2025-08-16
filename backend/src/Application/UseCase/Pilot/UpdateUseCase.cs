using Application.Interfaces.PilotInterfaces;
using Communication.Requests.Pilot;

namespace Application.UseCase.Pilot
{
    public class UpdateUseCase
    {
        private IPilotUpdateService _pilotService;

        public UpdateUseCase(IPilotUpdateService pilotService)
        {
            _pilotService = pilotService;
        }

        public async Task Execute(Guid id, PutRecordRequest request)
        {
            await _pilotService.UpdatePilotAsync(id, request);
        }
    }
}
