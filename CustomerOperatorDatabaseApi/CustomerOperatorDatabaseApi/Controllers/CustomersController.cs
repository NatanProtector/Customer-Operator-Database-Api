using Microsoft.AspNetCore.Mvc;

namespace CustomerOperatorDatabaseApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomersController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Customers Controller");
        }
    }
}
