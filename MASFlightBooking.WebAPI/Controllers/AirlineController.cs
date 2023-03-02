using MASFlightBooking.DataAccess.Services.Interfaces;
using MASFlightBooking.Domain.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MASFlightBooking.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AirlineController : ControllerBase
    {
        private readonly IAirline _airline;

        public AirlineController(IAirline airline)
        {
            _airline= airline;
        }

       [HttpGet("GetAirlines")]

       public async Task<IActionResult> AirlineList()
       {
            var list = await _airline.GetAllAirlines();
            if (list == null)
            {
                return NotFound();
            }
            return Ok(list);
       }

        [HttpGet("{Id}")]

        public async Task<IActionResult> AirlineList(Guid Id)
        {
            var list = await _airline.GetSingleAirline(Id);
            if (list == null)
            {
               return NotFound();

            }
            return Ok(list);
        }

        
        [HttpPost("Create-Airline")]

        public async Task<IActionResult> CreateAirline(AirlineViewModel model)
        {
            var create = await _airline.AddAirline(model);
            if (create == true)
            {
                return Ok("Airline created");  

            }
            return BadRequest();
        }

        [HttpPut("Update-Airline")]

        public async Task<IActionResult> UpdateAirline(AirlineViewModel model)
        {
            var create = await _airline.AddAirline(model);
            if (create == true)
            {
                return Ok("Airline updated");

            }
            return BadRequest();
        }

        [HttpDelete("Delete-Airline")]

        public IActionResult DeleteAirline(Guid Id)
        {
            _airline.DeleteAirline(Id);
            return Ok("Airline deleted successfully");
        }



    }
}
