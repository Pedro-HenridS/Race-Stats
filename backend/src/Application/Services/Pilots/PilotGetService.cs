using Application.Interfaces.PilotInterfaces;
using Communication.Responses.Pilot;
using Domain.Dto.Filter;
using Domain.Dto.PilotsDto;
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


        public async Task<List<CategoryPilotResponse>> GetFilteredAsync(PilotFilterRequest filters)
        {
            var pilots = await _pilotRepository.GetFilteredAsync(filters);

            if (pilots is null)
            {
                throw new RaceException(ResourceErrorMessages.PILOTS_NOT_FOUND, 404);
            }

            var response = pilots.Select(c => new CategoryPilotResponse
            {

                Category = c.Category.ToString(),
                pilotDTOs = c.pilotDTOs.Select(p => new PilotResponse
                {
                    Name = p.Name,
                    Fastestlap = p.Fastestlap,
                    Weight = p.Weight,
                    Gender = (Communication.Enums.GenderDto)p.Gender,
                    Nationality = p.Nationality,
                    Circuit = p.Circuit,
                    TeamId = p.TeamId,
                    Category = p.Category.ToString(),
                }).ToList()

            }).ToList();

            return response;
        }
    }
}
