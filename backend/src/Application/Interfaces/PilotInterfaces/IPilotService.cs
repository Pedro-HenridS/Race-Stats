using Communication.Responses.Pilot;
using Domain.Entities;

namespace Application.Interfaces.PilotInterfaces
{
    public interface IPilotService
    {
        public Task<List<PilotResponse>> GetAllPilotAsync();

        public Task<PilotResponse> GetPilotById(Guid id);
    }
}
