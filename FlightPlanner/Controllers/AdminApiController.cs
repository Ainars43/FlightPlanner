using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Threading.Tasks;
using FlightPlanner.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace FlightPlanner.Controllers
{
    [Route("admin-api")]
    [ApiController, Authorize, EnableCors]
    public class AdminApiController : ControllerBase
    {
        private readonly object balanceLock = new object();
        private readonly FlightPlannerDbContext _context;
        private readonly IEnumerable<IValidator> _validators;
        private readonly IFlightStorage _flightStorage;

        public AdminApiController(FlightPlannerDbContext context, IEnumerable<IValidator> validators, IFlightStorage flightStorage)
        {
            _context = context;
            _validators = validators;
            _flightStorage = flightStorage;
        }

        [Route("flights/{id}")]
        [HttpGet]
        public IActionResult GetFlight(int id)
        {
            var flight = _context.Flights.
                Include(f => f.From).
                Include(f => f.To).FirstOrDefault(f => f.Id == id);

            if (flight == null)
            {
                return NotFound();
            }

            return Ok(flight);

            //return flight == null ? NotFound() : (IActionResult)Ok(flight);
        }

        [Route("flights")]
        [HttpPut]
        public IActionResult PutFlight(Flight flight)
        {
            
            if (!_validators.All(validator => validator.Validate(flight)))
            {
                return BadRequest();
            }

            lock (balanceLock)
            {
                if (_flightStorage.FlightAlreadyExists(flight))
                {
                    return Conflict();
                }

                _context.Flights.Add(flight);
                _context.SaveChanges();
                return Created("", flight);
            }
        }

        [Route("flights/{id}")]
        [HttpDelete]
        public IActionResult DeleteFlight(int id)
        {
            lock (balanceLock)
            {
                var flight = _context.Flights.FirstOrDefault(f => f.Id == id);
                if (flight == null) return Ok();
                _context.Flights.Remove(flight);
                _context.SaveChanges();

                return Ok();
            }
        }
    }
}
