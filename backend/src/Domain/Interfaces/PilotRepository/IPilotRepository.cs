

using Domain.Entities;

namespace Domain.Interfaces.PilotRepository
{
    public interface IPilotRepository
    {
        public Task<List<Pilot>> GetPilots();
        public Task<Pilot> GetPilotById(Guid id);
        public Task UpdatePilot(Pilot pilot); 
    }
}
