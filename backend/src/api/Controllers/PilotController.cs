using Application.UseCase.Pilot;
using Communication.Requests.Pilot;
using Communication.Responses.Pilot;
using Domain.Dto.Filter;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("/pilots")]
    [ApiController]
    public class PilotController : ControllerBase
    {
        private readonly GetAllUseCase _getAllUseCase;
        private readonly UpdateUseCase _updateUseCase;

        public PilotController(
            GetAllUseCase getAllUseCase,
            UpdateUseCase updateUseCase)
        {
            _getAllUseCase = getAllUseCase;
            _updateUseCase = updateUseCase;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<PilotResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(object), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(object), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAll([FromQuery] PilotFilterRequest filters)
        {
            var pilots = await _getAllUseCase.Execute(filters);

            return Ok(pilots);
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
