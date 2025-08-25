using Domain.Dto.Filter;
using Domain.Dto.PilotsDto;
using Domain.Dto.TeamsDto;
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

        public async Task<List<TeamPilotsDto>> GetTeams(TeamFilterRequest filters)
        {

            var query = _context.Teams.Include(t => t.Pilots).AsQueryable();

            if (filters.TeamId.HasValue)
            {
                query = query.Where(t => t.Id == filters.TeamId.Value);
            }

            if (!string.IsNullOrEmpty(filters.Search))
            {
                var term = filters.Search.ToLower();

                query = query.Where(p =>
                    p.Name.ToLower().Contains(term) ||
                    p.Pilots.Any(p => p.Name.ToLower().Contains(term)));
            }

            var teams = await query
                .Select(t => new TeamPilotsDto
                {
                    Id = t.Id,
                    Team = t.Name,
                    Color = t.Color,
                    Pilots = t.Pilots.Select(p => new PilotDTO
                    {
                        Id = p.Id,
                        Name = p.Name,
                        Nationality = p.Nationality,
                        Gender = p.Gender,
                        TeamId = p.TeamId,
                        TeamName = p.Team.Name,
                        Circuit = p.Circuit,
                    }).ToList()
                })
                .ToListAsync();

            return teams;
        }
    }
}
