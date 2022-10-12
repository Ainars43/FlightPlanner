using System.Threading.Tasks;
using FlightPlanner.Core;
using FlightPlanner.Data;
using Microsoft.AspNetCore.Mvc;

namespace FlightPlanner.Controllers
{
    [Route("testing-api")]
    [ApiController]
    public class TestingApiController : ControllerBase
    {
        private readonly IDbExtendedService _service;

        public TestingApiController(IDbExtendedService service)
        {
            _service = service;
        }

        [HttpPost]
        [Route("clear")]
        public IActionResult Clear()
        {
            _service.DeleteAll();
            return Ok();
        }
    }
}
