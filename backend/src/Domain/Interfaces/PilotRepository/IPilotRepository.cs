

using Domain.Dto.PilotsDto;
using Domain.Dto.TeamsDto;
using Domain.Entities;

namespace Domain.Interfaces.PilotRepository
{
    public interface IPilotRepository
    {
        public Task<List<CategoryPilotsDto>> GetPilots();
        public Task<List<TeamPilotsDto>> GetPilotsGroupByEquip(string category);
        public Task<Pilot> GetPilotById(Guid id);
        public Task UpdatePilot(Pilot pilot);
    }
}
