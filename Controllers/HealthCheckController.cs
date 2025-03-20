using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace jiraApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HealthCheckController : ControllerBase
    {
        [HttpGet]
        public IActionResult get()
        {
            return Ok("Health Check");
        }

    }
}
