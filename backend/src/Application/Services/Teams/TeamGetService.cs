using Application.Interfaces.TeamInterfaces;
using Communication.Enums;
using Communication.Requests.Team;
using Communication.Responses.Pilot;
using Communication.Responses.Team;
using Domain.Interfaces.TeamRepository;
using Exception;

namespace Application.Services.Teams
{

    public class TeamGetService : ITeamGetService
    {
        private readonly ITeamRepository _teamRepository;

        // O construtor injeta a dependência do repositório de times.
        public TeamGetService(
            ITeamRepository teamRepository
            )
        {
            _teamRepository = teamRepository;
        }

        public async Task<List<TeamResponse>> GetTeams(TeamFilterRequest filter)
        {
            // Mapeia os filtros de requisição para o formato.
            var teams = await _teamRepository.GetTeams(new Domain.Dto.Filter.TeamFilterRequest { TeamId = filter.Team ?? null, Search = filter.Search ?? "" });

            // Lança uma exceção se nenhum time for encontrado.
            if (teams is null)
            {
                throw new RaceException(ResourceErrorMessages.PILOTS_NOT_FOUND, 404);
            }

            // Mapeia os dados do domínio para o DTO de resposta.
            List<TeamResponse> response = teams.Select(t => new TeamResponse
            {
                Id = t.Id,
                Team = t.Team,
                Color = t.Color,
                Pilots = t.Pilots.Select(p => new PilotResponse
                {
                    Id = p.Id,
                    Name = p.Name,
                    Fastestlap = p.Fastestlap,
                    Weight = p.Weight,
                    Gender = (GenderDto)p.Gender,
                    Nationality = p.Nationality,
                    Circuit = p.Circuit,
                    TeamId = p.TeamId,
                    TeamName = p.TeamName,
                    Category = (SingleSeaterCategoryDto)p.Category
                }).ToList()
            }).ToList();

            return response;
        }
    }
}
