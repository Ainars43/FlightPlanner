using System.Linq;
using AutoMapper;
using FlightPlanner.Core;
using FlightPlanner.Core.Models;
using FlightPlanner.Core.Requests;
using Microsoft.AspNetCore.Mvc;

namespace FlightPlanner.Controllers
{
    [Route("api")]
    [ApiController]
    public class CustomerApiController : ControllerBase
    {
        private static readonly object balanceLock = new object();
        private readonly IFlightService _flightService;
        private readonly IAirportService _airportService;
        private readonly IMapper _mapper;

        public CustomerApiController(IFlightService flightService, IAirportService airportService, IMapper mapper)
        {
            _flightService = flightService;
            _airportService = airportService;
            _mapper = mapper;
        }

        [Route("airports")]
        [HttpGet]
        public IActionResult SearchAirports(string search)
        {
            lock (balanceLock)
            {
                var result = _airportService.SearchAirports(search);

                return result.Any() ? Ok(result.Select(a => _mapper.Map<AirportRequest>(a)).ToList()) : NotFound();
            }
        }

        [Route("flights/search")]
        [HttpPost]
        public IActionResult SearchFlights(FlightSearchRequest request)
        {
            if (_flightService.IsValidFlightSearchRequest(request))
            {
                return BadRequest();
            }

            lock (balanceLock)
            {
                var flightSearchResult = _flightService.SearchFlights(request);
                var pageResult = new PageResult<FlightRequest>
                {
                    Page = 0,
                    TotalItems = flightSearchResult.Count(),
                    Items = flightSearchResult.Select(f => _mapper.Map<FlightRequest>(f)).ToList()
                };

                return Ok(pageResult);
            }
        }

        [Route("flights/{id:int}")]
        [HttpGet]
        public IActionResult GetFlights(int id)
        {
            var flight = _flightService.GetFlight(id);

            return flight == null ? NotFound() : (IActionResult)Ok(_mapper.Map<FlightRequest>(flight));
        }
    }
}
