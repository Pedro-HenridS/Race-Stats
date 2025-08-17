

using Domain.Entities;

namespace Domain.Interfaces.PilotRepository
{
    public interface IPilotRepository
    {
        public Task<List<Pilot>> GetPilots();
        public Task<List<TeamPilotsRepository>> GetPilotsGroupByEquip();
        public Task<Pilot> GetPilotById(Guid id);
        public Task UpdatePilot(Pilot pilot);
    }
}
