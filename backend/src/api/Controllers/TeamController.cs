using Application.UseCase.Team;
using Communication.Responses.Team;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("/teams")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        GetAllTeamsUseCase _getAllTeamsUseCase;

        public TeamController(GetAllTeamsUseCase getAllTeamsUseCase)
        {
            _getAllTeamsUseCase = getAllTeamsUseCase;
        }
        [HttpGet]
        [ProducesResponseType(typeof(List<TeamResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(object), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(object), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllTeams()
        {
            var response = await _getAllTeamsUseCase.Execute();

            return Ok(response);
        }
    }
}
