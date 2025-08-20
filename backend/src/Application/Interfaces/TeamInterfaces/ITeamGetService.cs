using Communication.Responses.Team;

namespace Application.Interfaces.TeamInterfaces
{
    public interface ITeamGetService
    {
        public Task<List<TeamResponse>> GetTeams();
    }
}
