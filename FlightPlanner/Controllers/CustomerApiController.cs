using System.Linq;
using FlightPlanner.Core;
using FlightPlanner.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace FlightPlanner.Controllers
{
    [Route("api")]
    [ApiController]
    public class CustomerApiController : ControllerBase
    {
        private static readonly object balanceLock = new object();
        private readonly IFlightStorage _flightStorage;

        public CustomerApiController(IFlightStorage flightStorage)
        {
            
            _flightStorage = flightStorage;
        }

        [Route("airports")]
        [HttpGet]
        public IActionResult SearchAirports(string search)
        {
            lock (balanceLock)
            {
                var result = _flightStorage.FindAirports(search);
                return result.Any() ? Ok(result) : NotFound();
            }
        }

        [Route("flights/search")]
        [HttpPost]
        public IActionResult SearchFlights(FlightSearchRequest request)
        {
            if (_flightStorage.IsValidFlightSearchRequest(request))
            {
                return BadRequest();
            }

            lock (balanceLock)
            {
                var flightSearchResult = _flightStorage.SearchFlights(request);
                var pageResult = new PageResult<Flight>
                {
                    Page = 0,
                    TotalItems = flightSearchResult.Count(),
                    Items = flightSearchResult.ToList()
                };

                return Ok(pageResult);
            }
        }

        [Route("flights/{id}")]
        [HttpGet]
        public IActionResult GetFlights(int id)
        {
            var flight = _flightStorage.GetFlight(id);
            return flight == null ? NotFound() : Ok(flight);
        }
    }
}
