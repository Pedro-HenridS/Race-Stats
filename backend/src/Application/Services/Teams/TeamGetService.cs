using Application.Interfaces.TeamInterfaces;
using Communication.Enums;
using Communication.Responses.Pilot;
using Communication.Responses.Team;
using Domain.Interfaces.TeamRepository;
using Exception;

namespace Application.Services.Teams
{
    public class TeamGetService : ITeamGetService
    {
        private readonly ITeamRepository _pilotRepository;

        public TeamGetService(
            ITeamRepository pilotRepository
            )
        {
            _pilotRepository = pilotRepository;
        }
        public async Task<List<TeamResponse>> GetTeams()
        {
            var teams = await _pilotRepository.GetTeams();

            if (teams is null)
            {
                throw new RaceException(ResourceErrorMessages.PILOTS_NOT_FOUND, 404);
            }

            List<TeamResponse> response = teams.Select(t => new TeamResponse
            {
                Id = t.Id,
                Team = t.Team,
                Color = t.Color,
                Pilots = t.Pilots.Select(p => new PilotResponse
                {
                    Id = p.Id,
                    Name = p.Name,
                    Fastestlap = p.Fastestlap,
                    Weight = p.Weight,
                    Gender = (GenderDto)p.Gender,
                    Nationality = p.Nationality,
                    Circuit = p.Circuit,
                    TeamId = p.TeamId,
                    TeamName = p.TeamName,
                    Category = p.Category.ToString()
                }).ToList()

            }).ToList();

            return response;
        }
    }
}
