using Application.UseCase.Team;
using Communication.Requests.Team;
using Communication.Responses.Team;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{

    [Route("/teams")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        private GetAllTeamsUseCase _getAllTeamsUseCase;

        // O construtor injeta o caso de uso de obtenção de todos os times.
        public TeamController(GetAllTeamsUseCase getAllTeamsUseCase)
        {
            _getAllTeamsUseCase = getAllTeamsUseCase;
        }

        // Endpoint HTTP GET para obter todos os times.
        [HttpGet]
        // Define os tipos de resposta HTTP esperados.
        [ProducesResponseType(typeof(List<TeamResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(object), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(object), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllTeams([FromQuery] TeamFilterRequest filter)
        {
            var response = await _getAllTeamsUseCase.Execute(filter);

            return Ok(response);
        }
    }
}
