
using Domain.Dto.Filter;
using Domain.Dto.TeamsDto;

namespace Domain.Interfaces.TeamRepository
{
    public interface ITeamRepository
    {
        public Task<List<TeamPilotsDto>> GetTeams(TeamFilterRequest filters);
    }
}
