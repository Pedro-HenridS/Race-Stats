using Application.Interfaces.TeamInterfaces;
using Communication.Requests.Team;
using Communication.Responses.Team;

namespace Application.UseCase.Team
{
    public class GetAllTeamsUseCase
    {
        private ITeamGetService _teamGetService;

        // O construtor injeta o serviço de times.
        public GetAllTeamsUseCase(ITeamGetService teamGetService)
        {
            _teamGetService = teamGetService;
        }

        // Este método executa a lógica de busca e retorna a lista de times.
        public async Task<List<TeamResponse>> Execute(TeamFilterRequest filter)
        {
            return await _teamGetService.GetTeams(filter);
        }
    }
}
