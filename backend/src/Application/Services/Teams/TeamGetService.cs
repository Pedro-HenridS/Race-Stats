using Application.Interfaces.TeamInterfaces;
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

            var response = teams.Select(c => new TeamResponse
            {
                Id = c.Id,
                Name = c.Name,
                CreatedAt = c.CreatedAt


            }).ToList();

            return response;
        }
    }
}
