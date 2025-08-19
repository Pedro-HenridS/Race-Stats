using Application.Interfaces.PilotInterfaces;
using Domain.Dto.PilotsDto;

namespace Application.UseCase.Pilot
{
    public class GetAllUseCase
    {
        private IPilotGetService _pilotService;

        public GetAllUseCase(IPilotGetService pilotService)
        {
            _pilotService = pilotService;
        }

        public async Task<List<CategoryPilotResponse>> Execute()
        {
            return await _pilotService.GetAllPilotAsync();
        }
    }
}
