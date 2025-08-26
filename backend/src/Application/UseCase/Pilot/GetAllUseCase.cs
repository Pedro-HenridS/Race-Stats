using Application.Interfaces.PilotInterfaces;
using Communication.Requests.Pilot;
using Communication.Responses.Pilot;

namespace Application.UseCase.Pilot
{
    public class GetAllUseCase
    {
        private IPilotGetService _pilotService;

        // O construtor injeta o serviço de busca de pilotos.
        public GetAllUseCase(IPilotGetService pilotService)
        {
            _pilotService = pilotService;
        }

        // Este método executa a lógica de busca e retorna a lista de pilotos.
        public async Task<List<CategoryPilotResponse>> Execute(GetFilteredPilotRequest filters)
        {
            return await _pilotService.GetFilteredAsync(filters);
        }
    }
}
