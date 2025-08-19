using Application.Interfaces.PilotInterfaces;
using Application.Mapping;
using Communication.Enums;
using Communication.Responses.Pilot;
using Domain.Dto.PilotsDto;
using Domain.Dto.TeamsDto;
using Domain.Interfaces.PilotRepository;
using Exception;

namespace Application.Services.Pilots
{
    public class PilotGetService : IPilotGetService
    {
        private readonly IPilotRepository _pilotRepository;
        private PilotMapping _pilotMapping;

        public PilotGetService(
            IPilotRepository pilotRepository,
            PilotMapping pilotMapping
            )
        {
            _pilotRepository = pilotRepository;
            _pilotMapping = pilotMapping;
        }

        public async Task<List<CategoryPilotResponse>> GetAllPilotAsync()
        {
            var pilots = await _pilotRepository.GetPilots();

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
                    Gender = (Gender)p.Gender,
                    Nationality = p.Nationality,
                    Circuit = p.Circuit,
                    TeamId = p.TeamId,
                    Category = p.Category.ToString(),
                }).ToList()

            }).ToList();

            return response;
        }

        public async Task<PilotResponse> GetPilotByIdAsync(Guid id)
        {
            var pilot = await _pilotRepository.GetPilotById(id);

            if (pilot is null)
            {
                throw new RaceException(ResourceErrorMessages.PILOTS_NOT_FOUND, 404);
            }

            var response = _pilotMapping.MapToResponse(pilot);

            return response;
        }

        public async Task<List<TeamPilotsDto>> GetPilotsByTeamsAsync(string category)
        {
            var response = await _pilotRepository.GetPilotsGroupByEquip(category);

            if (response is null)
            {
                throw new RaceException(ResourceErrorMessages.PILOTS_NOT_FOUND, 404);
            }

            return response;
        }
    }
}
