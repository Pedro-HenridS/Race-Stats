using Application.UseCase.Pilot;
using Communication.Responses.Pilot;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("pilots")]
    [ApiController]
    public class PilotController : ControllerBase
    {
        private readonly GetAllUseCase _getAllUseCase;
        private readonly GetByIdUseCase _getByIdUseCase;

        public PilotController(GetAllUseCase getAllUseCase, GetByIdUseCase getByIdUseCase)
        {
            _getAllUseCase = getAllUseCase;
            _getByIdUseCase = getByIdUseCase;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<PilotResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(object), StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(object), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAll()
        {
            var pilots = await _getAllUseCase.Execute();

            return Ok(pilots);
        }

        [HttpGet]
        [Route("/{id}")]
        [ProducesResponseType(typeof(List<PilotResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(object), StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(object), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var pilot = await _getByIdUseCase.Execute(id);

            return Ok(pilot);
        }
    }
}
