using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("pilots")]
    [ApiController]
    public class PilotController : ControllerBase
    {

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok("");
        }
    }
}
