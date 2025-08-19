using Domain.Dto.Filter;
using Domain.Dto.PilotsDto;

namespace Application.Interfaces.PilotInterfaces
{
    public interface IPilotGetService
    {
        public Task<List<CategoryPilotResponse>> GetFilteredAsync(PilotFilterRequest filters);

    }
}
