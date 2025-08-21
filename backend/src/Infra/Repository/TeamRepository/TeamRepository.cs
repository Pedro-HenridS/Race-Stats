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

        public async Task<List<TeamPilotsDto>> GetTeams()
        {
            var teams = await _context.Teams
                .Include(t => t.Pilots)
                .Select(t => new TeamPilotsDto
                {
                    Team = t.Name,
                    Color = t.Color,
                    Pilots = t.Pilots.Select(p => new PilotDTO
                    {
                        Id = p.Id,
                        Name = p.Name,
                        Nationality = p.Nationality,
                        Gender = p.Gender,
                        TeamId = p.TeamId,
                        Circuit = p.Circuit,

                    }).ToList()
                })
                .ToListAsync();

            return teams;
        }
    }
}
