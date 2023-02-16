using MASFlightBooking.DataAccess.Services.Interfaces;
using MASFlightBooking.Domain.Models;
using MASFlightBooking.Domain.Models.Payments;
using MASFlightBooking.Domain.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MASFlightBooking.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MASFlightController : ControllerBase
    {
        private readonly IMASFlightInterface _masFlightInterface;

        //decimal totalAmount = 0;
        //decimal Amount_per_seat;
        //int Number_of_Passanger;

        public MASFlightController(IMASFlightInterface masFlightInterface)
        {
            _masFlightInterface = masFlightInterface;
        }
       
        [HttpGet("GetAllFlights")]
        public async Task<IActionResult> GetList()
        {
            var allflights = await _masFlightInterface.GetAllFlight();
            if(allflights == null)
            {
                return NotFound();
            }
            return Ok(allflights);
        }

        [HttpGet("Get-Single-Flight")]
        public async Task<IActionResult> GetSingleFlight(Guid Id)
        {
            var allflights = await _masFlightInterface.GetSingleFlight(Id);    
            if(allflights != null)
            {
                return Ok(allflights);

            }
            return NotFound(Id);

        }
        [HttpPost("Book-Flight")]
        public async Task<IActionResult> CreateBooking(CreateBookingViewModel model)
        {
            
            try
            {
                var purchase = await _masFlightInterface.CreateBooking(model);

                return Ok(purchase);
            }
            catch (Exception ex)
            {
                throw;

            }


        }


    }
}
