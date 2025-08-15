using Communication.Responses.Pilot;

namespace Application.Interfaces.PilotInterfaces
{
    public interface IPilotService
    {
        public Task<List<PilotResponse>> GetAllPilotAsync();
    }
}
