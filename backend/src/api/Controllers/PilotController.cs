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

        public PilotController(GetAllUseCase getAllUseCase)
        {
            _getAllUseCase = getAllUseCase;
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
        public async Task<IActionResult> GetById()
        {
            return Ok("");
        }
    }
}
