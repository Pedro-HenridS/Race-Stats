using Domain.Dto.Filter;
using Domain.Dto.PilotsDto;
using Domain.Dto.TeamsDto;
using Domain.Interfaces.TeamRepository;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repository.TeamRepository
{
    // Repositório para operações de dados de times.
    public class TeamRepository : ITeamRepository
    {
        private AppDbContext _context;

        // Injeta o contexto do banco de dados no construtor.
        public TeamRepository(
            AppDbContext context
        )
        {
            _context = context;
        }

        // Retorna uma lista de times com seus pilotos, aplicando filtros.
        public async Task<List<TeamPilotsDto>> GetTeams(TeamFilterRequest filters)
        {
            // Inicia uma query, incluindo a navegação para a entidade Pilots.
            var query = _context.Teams.Include(t => t.Pilots).AsQueryable();

            // Aplica o filtro por ID do time, se for fornecido.
            if (filters.TeamId.HasValue)
            {
                query = query.Where(t => t.Id == filters.TeamId.Value);
            }

            // Aplica o filtro de busca por nome do time ou nome de piloto.
            if (!string.IsNullOrEmpty(filters.Search))
            {
                var term = filters.Search.ToLower();

                query = query.Where(p =>
                    p.Name.ToLower().Contains(term) ||
                    p.Pilots.Any(p => p.Name.ToLower().Contains(term)));
            }

            // Executa a query e projeta o resultado para o DTO.
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
