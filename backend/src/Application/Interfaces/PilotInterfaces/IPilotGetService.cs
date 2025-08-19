using Communication.Responses.Pilot;
using Domain.Dto.PilotsDto;
using Domain.Dto.TeamsDto;

namespace Application.Interfaces.PilotInterfaces
{
    public interface IPilotGetService
    {
        public Task<List<CategoryPilotResponse>> GetAllPilotAsync();

        public Task<PilotResponse> GetPilotByIdAsync(Guid id);
        public Task<List<TeamPilotsDto>> GetPilotsByTeamsAsync(string category);

    }
}
