using Communication.Responses.Pilot;
using Domain.Interfaces.PilotRepository;

namespace Application.Interfaces.PilotInterfaces
{
    public interface IPilotGetService
    {
        public Task<List<PilotResponse>> GetAllPilotAsync();

        public Task<PilotResponse> GetPilotByIdAsync(Guid id);
        public Task<List<TeamPilotsRepository>> GetPilotsByTeamsAsync();

    }
}
