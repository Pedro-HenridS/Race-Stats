using Domain.Entities;

namespace Domain.Interfaces.TeamRepository
{
    public interface ITeamRepository
    {
        public Task<List<Team>> GetTeams();
    }
}
