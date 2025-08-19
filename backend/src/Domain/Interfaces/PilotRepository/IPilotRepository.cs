

using Domain.Dto.Filter;
using Domain.Dto.PilotsDto;
using Domain.Entities;

namespace Domain.Interfaces.PilotRepository
{
    public interface IPilotRepository
    {
        public Task UpdatePilot(Pilot pilot);
        public Task<Pilot> GetPilotById(Guid id);
        public Task<List<CategoryPilotsDto>> GetFilteredAsync(PilotFilterRequest filters);
    }
}
