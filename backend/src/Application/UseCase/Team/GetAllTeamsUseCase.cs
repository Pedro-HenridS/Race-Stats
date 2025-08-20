using Application.Interfaces.TeamInterfaces;
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

        public async Task<List<TeamResponse>> Execute()
        {
            return await _teamGetService.GetTeams();
        }
    }
}
