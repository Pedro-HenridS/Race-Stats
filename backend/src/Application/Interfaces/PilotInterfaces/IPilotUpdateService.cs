using Communication.Requests.Pilot;

namespace Application.Interfaces.PilotInterfaces
{
    public interface IPilotUpdateService
    {
        public Task UpdatePilotAsync(Guid id, PutRecordRequest request);

    }
}
