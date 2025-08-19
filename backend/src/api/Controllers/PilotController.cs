using Application.UseCase.Pilot;
using Communication.Requests.Pilot;
using Communication.Responses.Pilot;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("pilots")]
    [ApiController]
    public class PilotController : ControllerBase
    {
        private readonly GetAllUseCase _getAllUseCase;
        private readonly GetByIdUseCase _getByIdUseCase;
        private readonly UpdateUseCase _updateUseCase;
        private readonly GetPilotsByTeam _getPilotsByTeam;

        public PilotController(GetAllUseCase getAllUseCase, GetByIdUseCase getByIdUseCase, UpdateUseCase updateUseCase, GetPilotsByTeam getPilotsByTeam)
        {
            _getAllUseCase = getAllUseCase;
            _getByIdUseCase = getByIdUseCase;
            _updateUseCase = updateUseCase;
            _getPilotsByTeam = getPilotsByTeam;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<PilotResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(object), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(object), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAll()
        {
            var pilots = await _getAllUseCase.Execute();

            return Ok(pilots);
        }

        [HttpGet]
        [Route("/teams")]
        [ProducesResponseType(typeof(List<PilotResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(object), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(object), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllGroups([FromQuery] string category)
        {
            var pilots = await _getPilotsByTeam.Execute(category);

            return Ok(pilots);
        }

        [HttpGet]
        [Route("/{id}")]
        [ProducesResponseType(typeof(List<PilotResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(object), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(object), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var pilot = await _getByIdUseCase.Execute(id);

            return Ok(pilot);
        }

        [HttpPut]
        [Route("record/{id}")]
        [ProducesResponseType(typeof(List<PilotResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(object), StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(object), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> PutRecord([FromRoute] Guid id, [FromBody] PutRecordRequest request)
        {
            await _updateUseCase.Execute(id, request);

            return NoContent();
        }
    }
}
