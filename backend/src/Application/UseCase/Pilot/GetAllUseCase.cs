using Application.Interfaces.PilotInterfaces;
using Communication.Requests.Pilot;
using Communication.Responses.Pilot;

namespace Application.UseCase.Pilot
{
    public class GetAllUseCase
    {
        private IPilotGetService _pilotService;

        public GetAllUseCase(IPilotGetService pilotService)
        {
            _pilotService = pilotService;
        }

        public async Task<List<CategoryPilotResponse>> Execute(GetFilteredPilotRequest filters)
        {
            return await _pilotService.GetFilteredAsync(filters);
        }
    }
}
