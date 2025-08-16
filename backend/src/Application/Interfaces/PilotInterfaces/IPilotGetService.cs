using Communication.Requests.Pilot;
using Communication.Responses.Pilot;

namespace Application.Interfaces.PilotInterfaces
{
    public interface IPilotGetService
    {
        public Task<List<PilotResponse>> GetAllPilotAsync();

        public Task<PilotResponse> GetPilotByIdAsync(Guid id);
    }
}
