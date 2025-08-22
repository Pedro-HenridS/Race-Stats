using Application.Interfaces.TeamInterfaces;
using Communication.Requests.Team;
using Communication.Responses.Team;

namespace Application.UseCase.Team
{
    public class GetAllTeamsUseCase
    {
        ITeamGetService _teamGetService;

        public GetAllTeamsUseCase(ITeamGetService teamGetService)
        {
            _teamGetService = teamGetService;
        }

        public async Task<List<TeamResponse>> Execute(TeamFilterRequest filter)
        {
            return await _teamGetService.GetTeams(filter);
        }
    }
}
