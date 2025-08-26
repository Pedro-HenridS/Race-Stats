using Application.UseCase.Pilot;
using Communication.Requests.Pilot;
using Domain.Dto.PilotsDto;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{

    [Route("/pilots")]
    [ApiController]
    public class PilotController : ControllerBase
    {
        private readonly GetAllUseCase _getAllUseCase;
        private readonly AddPilotUseCase _addPilotUseCase;

        // O construtor injeta as dependências dos casos de uso.
        public PilotController(GetAllUseCase getAllUseCase, AddPilotUseCase addPilotUseCase)
        {
            _getAllUseCase = getAllUseCase;
            _addPilotUseCase = addPilotUseCase;
        }

        // Endpoint HTTP GET para obter todos os pilotos com filtros.
        [HttpGet]
        // Define os tipos de resposta HTTP esperados.
        [ProducesResponseType(typeof(List<PilotRequest>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(object), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(object), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAll([FromQuery] GetFilteredPilotRequest filters)
        {
            var pilots = await _getAllUseCase.Execute(filters);

            return Ok(pilots);
        }

        // Endpoint HTTP POST para adicionar um novo piloto.
        [HttpPost]
        [Route("add")]
        [ProducesResponseType(typeof(object), StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(object), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AddPilot([FromBody] PostPilotRequest request)
        {
            await _addPilotUseCase.Execute(request);

            return NoContent();
        }
    }
}
