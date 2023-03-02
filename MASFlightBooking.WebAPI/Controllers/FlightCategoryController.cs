using MASFlightBooking.DataAccess.Services.Interfaces;
using MASFlightBooking.Domain.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MASFlightBooking.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightCategoryController : ControllerBase
    {
        private readonly IFlightCategory _flightCategory;

        public FlightCategoryController(IFlightCategory flightCategory)
        {
            _flightCategory = flightCategory;
        }

        [HttpGet("GetCategory")]

        public async Task<IActionResult> AirlineList()
        {
            var list = await _flightCategory.GetAllCategory();
            if (list == null)
            {
                return NotFound();
            }
            return Ok(list);
        }

        [HttpGet("{Id}")]

        public async Task<IActionResult> CategoryList(Guid Id)
        {
            var list = await _flightCategory.GetSingleCategory(Id);
            if (list == null)
            {
                return NotFound();

            }
            return Ok(list);
        }


        [HttpPost("Create-Category")]

        public async Task<IActionResult> CreateCategory(FlightCategoryViewModel model)
        {
            var create = await _flightCategory.AddCategory(model);
            if (create == true)
            {
                return Ok("Flight category created");

            }
            return BadRequest();
        }

        [HttpPut("Update-Category")]

        public async Task<IActionResult> UpdateCategory(FlightCategoryViewModel model)
        {
            var create = await _flightCategory.UpdateCategory(model);
            if (create == true)
            {
                return Ok("Flight category updated");

            }
            return BadRequest();
        }

        [HttpDelete("Delete-Category")]

        public IActionResult DeleteCategory(Guid Id)
        {
            _flightCategory.DeleteCategory(Id);
            return Ok("Flight category deleted successfully");




        }
    }
}
