using Communication.Requests.Pilot;

namespace Application.Interfaces.PilotInterfaces
{
    public interface IPilotPostService
    {
        public Task CreatePilot(PostPilotRequest request);
    }
}
