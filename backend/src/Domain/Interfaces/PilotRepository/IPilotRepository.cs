

using Domain.Dto.Filter;
using Domain.Dto.PilotsDto;
using Domain.Entities;

namespace Domain.Interfaces.PilotRepository
{
    public interface IPilotRepository
    {
        public Task<Pilot> GetPilotByNameAsync(String name);
        public Task<Pilot> GetPilotByIdAsync(Guid id);
        public Task<List<CategoryPilotsDto>> GetFilteredAsync(PilotFilterRequest filters);
        public Task CreatePilot(PilotRequest pilot);

    }
}
