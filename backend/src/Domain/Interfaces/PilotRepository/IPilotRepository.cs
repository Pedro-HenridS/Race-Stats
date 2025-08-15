

using Domain.Entities;

namespace Domain.Interfaces.PilotRepository
{
    public interface IPilotRepository
    {
        public Task<List<Pilot>> GetPilots();
    }
}
