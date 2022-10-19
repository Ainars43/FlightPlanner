using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using FlightPlanner.Core.Interfaces;
using FlightPlanner.Core.Models;
using FlightPlanner.Core.Requests;
using FlightPlanner.Core.Services;
using FlightPlanner.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace FlightPlanner.Controllers
{
    [Route("admin-api")]
    [ApiController, Authorize, EnableCors]
    public class AdminApiController : ControllerBase
    {
        private readonly object balanceLock = new object();
        private readonly IEnumerable<IValidator> _validators;
        private readonly IFlightService _flightService;
        private readonly IMapper _mapper;

        public AdminApiController(IEnumerable<IValidator> validators, IFlightService flightService, IMapper mapper)
        {
            _validators = validators;
            _flightService = flightService;
            _mapper = mapper;
        }

        [Route("flights/{id:int}")]
        [HttpGet]
        public IActionResult GetFlight(int id)
        {
            var flight = _flightService.GetFlight(id);

            return flight == null ? NotFound() : (IActionResult)Ok(flight);
        }

        [Route("flights")]
        [HttpPut]
        public IActionResult PutFlight(FlightRequest request)
        {
            if (!_validators.All(validator => validator.Validate(request)))
            {
                return BadRequest();
            }

            lock (balanceLock)
            {
                if (_flightService.FlightAlreadyExists(request))
                {
                    return Conflict();
                }

                var flight = _mapper.Map<Flight>(request);
                _flightService.Create(flight);

                return Created("", _mapper.Map<FlightRequest>(flight));
            }
        }

        [Route("flights/{id}")]
        [HttpDelete]
        public IActionResult DeleteFlight(int id)
        {
            var flight = _flightService.GetByID(id);

            if (flight == null) return Ok();

            var result = _flightService.Delete(flight);

            if (result.Success)
            {
                return Ok();
            }

            return Problem(result.FormattedErrors);
        }
    }
}
