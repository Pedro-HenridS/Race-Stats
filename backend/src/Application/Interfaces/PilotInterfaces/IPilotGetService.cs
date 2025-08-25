using Communication.Requests.Pilot;
using Communication.Responses.Pilot;

namespace Application.Interfaces.PilotInterfaces
{
    public interface IPilotGetService
    {
        public Task<List<CategoryPilotResponse>> GetFilteredAsync(GetFilteredPilotRequest filters);

        public Task<bool> PilotExistsAsync(String name);
    }
}
