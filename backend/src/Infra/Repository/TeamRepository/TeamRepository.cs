using Domain.Entities;
using Domain.Interfaces.TeamRepository;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repository.TeamRepository
{
    public class TeamRepository : ITeamRepository
    {
        private AppDbContext _context;

        public TeamRepository(
            AppDbContext context
        )
        {
            _context = context;
        }

        public async Task<List<Team>> GetTeams()
        {
            return await _context.Teams.ToListAsync();
        }
    }
}
