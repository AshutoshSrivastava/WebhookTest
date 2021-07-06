using System.Linq;
using AirLineWeb.Data;
using AirLineWeb.Dtos;
using AirLineWeb.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AirLineWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly AirlineDbContext _context;

        public FlightsController(AirlineDbContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        [HttpGet("{flightCode}", Name = "GetFlightDetailByCode")]
        public ActionResult<FlightDetailReadDto> GetFlightDetailByCode(string flightCode)
        {
            var flight = _context.FlightDetails.FirstOrDefault(
                f => f.FlightCode == flightCode
            );
            if (flightCode == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<FlightDetailReadDto>(flight));
        }

        [HttpPost]
        public ActionResult<FlightDetailReadDto> CreateFlight(FlightDetailCreateDto flightDetailCreateDto)
        {
            var flight = _context.FlightDetails.FirstOrDefault(f => f.FlightCode == flightDetailCreateDto.FlightCode);
            if (flight == null)
            {
                var flightDetailModel = _mapper.Map<FlightDetail>(flightDetailCreateDto);

                try
                {
                    _context.FlightDetails.Add(flightDetailModel);
                    _context.SaveChanges();
                }
                catch (System.Exception ex)
                {
                    return BadRequest(ex.Message);
                }

                var flightDetailReadDto = _mapper.Map<FlightDetailReadDto>(flightDetailModel);

                return CreatedAtRoute(nameof(GetFlightDetailByCode), new { GetFlightDetailByCode = flightDetailReadDto.FlightCode }, flightDetailReadDto);
            }
            else
            {
                return NoContent();
            }
        }

        [HttpPut("{id}")]
        public ActionResult UpdateFlightDetail(int id, FlightDetailUpdateDto flightDetailUpdateDto)
        {
            var flight = _context.FlightDetails.FirstOrDefault(f=>f.Id == id);
            if(flight == null)
            {
                return NotFound();
            }
            _mapper.Map(flightDetailUpdateDto,flight);

            _context.SaveChanges();
            return NoContent();
        }
    }
}