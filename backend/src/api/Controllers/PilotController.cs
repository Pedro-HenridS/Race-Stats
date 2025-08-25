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
        private readonly UpdateUseCase _updateUseCase;
        private readonly AddPilotUseCase _addPilotUseCase;

        public PilotController(GetAllUseCase getAllUseCase, UpdateUseCase updateUseCase, AddPilotUseCase addPilotUseCase)
        {
            _getAllUseCase = getAllUseCase;
            _updateUseCase = updateUseCase;
            _addPilotUseCase = addPilotUseCase;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<PilotRequest>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(object), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(object), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAll([FromQuery] GetFilteredPilotRequest filters)
        {
            var pilots = await _getAllUseCase.Execute(filters);

            return Ok(pilots);
        }

        [HttpPost]
        [Route("add")]
        [ProducesResponseType(typeof(object), StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(object), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AddPilot([FromBody] PostPilotRequest request)
        {
            await _addPilotUseCase.Execute(request);

            return NoContent();
        }

        [HttpPut]
        [Route("record/{id}")]
        [ProducesResponseType(typeof(object), StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(object), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> PutRecord([FromRoute] Guid id, [FromBody] PutRecordRequest request)
        {
            await _updateUseCase.Execute(id, request);

            return NoContent();
        }
    }
}
