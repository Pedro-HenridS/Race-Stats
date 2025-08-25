using Application.Interfaces.PilotInterfaces;
using Communication.Enums;
using Communication.Requests.Pilot;
using Communication.Responses.Pilot;
using Domain.Dto.Filter;

using Domain.Interfaces.PilotRepository;
using Exception;

namespace Application.Services.Pilots
{
    public class PilotGetService : IPilotGetService
    {
        private readonly IPilotRepository _pilotRepository;

        public PilotGetService(
            IPilotRepository pilotRepository
            )
        {
            _pilotRepository = pilotRepository;
        }

        public async Task<List<CategoryPilotResponse>> GetFilteredAsync(GetFilteredPilotRequest filters)
        {
            var filter_handle = new PilotFilterRequest
            {
                Circuit = filters.Circuit,
                Gender = filters.Gender != null ? Enum.Parse<Domain.Enums.Gender>(filters.Gender.ToString()) : null,
                Nationality = filters.Nationality,
                Search = filters.Search,
                Team = filters.Team,
                weight = filters.weight != null ? Enum.Parse<Domain.Enums.Weight>(filters.weight.ToString()) : null
            };

            var pilots = await _pilotRepository.GetFilteredAsync(filter_handle);

            if (pilots is null)
            {
                throw new RaceException(ResourceErrorMessages.PILOTS_NOT_FOUND, 404);
            }

            var response = pilots.Select(c => new CategoryPilotResponse
            {

                Category = c.Category.ToString(),
                pilots = c.pilotDTOs.Select(p => new PilotResponse
                {
                    Id = p.Id,
                    Name = p.Name,
                    Fastestlap = p.Fastestlap,
                    Weight = (decimal)(GenderDto)p.Weight,
                    Gender = Enum.Parse<GenderDto>(p.Gender.ToString()),
                    Nationality = p.Nationality,
                    Circuit = p.Circuit,
                    TeamId = p.TeamId,
                    TeamName = p.TeamName,
                    Category = Enum.Parse<SingleSeaterCategoryDto>(p.Category.ToString()),
                }).ToList()

            }).ToList();

            return response;
        }
        public async Task<bool> PilotExistsAsync(String name)
        {
            var pilot = await _pilotRepository.GetPilotByNameAsync(name);

            if (pilot != null)
            {
                return true;
            }

            return false;
        }
    }
}
