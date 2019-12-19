using Microsoft.AspNetCore.Mvc;
using WeAppEip.Web.Controllers;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HealthCheckController : BaseApiController
    {
        [HttpGet("")]
        [HttpHead("")]
        public IActionResult Ping()
        {
            return Ok();
        }
    }
}