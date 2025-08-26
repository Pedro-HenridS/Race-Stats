using Application.Interfaces.PilotInterfaces;
using Communication.Requests.Pilot;
using Domain.Dto.PilotsDto;
using Domain.Enums;
using Domain.Interfaces.PilotRepository;

namespace Application.Services.Pilots
{
    public class PilotPostService : IPilotPostService
    {
        private readonly IPilotRepository _pilotRepository;

        // O construtor injeta o repositório de pilotos para acesso aos dados.
        public PilotPostService(IPilotRepository pilotRepository)
        {
            _pilotRepository = pilotRepository;
        }

        // Este método cria um novo piloto no banco de dados.
        public async Task CreatePilot(PostPilotRequest request)
        {
            // Mapeia os dados da requisição para o DTO de piloto.
            var pilot = new PilotRequest
            {
                Name = request.Name,
                Fastestlap = request.Fastestlap,
                Weight = request.Weight,
                Gender = Enum.Parse<Gender>(request.Gender.ToString()),
                Nationality = request.Nationality,
                Circuit = request.Circuit,
                TeamId = request.TeamId,
                Leader = request.Leader,
                Category = Enum.Parse<SingleSeaterCategory>(request.Category.ToString())
            };

            // Chama o método de criação no repositório.
            await _pilotRepository.CreatePilot(pilot);
        }
    }
}
