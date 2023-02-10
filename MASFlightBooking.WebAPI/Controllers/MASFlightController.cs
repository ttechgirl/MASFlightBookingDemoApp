using MASFlightBooking.DataAccess.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MASFlightBooking.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MASFlightController : ControllerBase
    {
        private readonly IMASFlightInterface _masFlightInterface;

        public MASFlightController(IMASFlightInterface masFlightInterface)
        {
            _masFlightInterface = masFlightInterface;
        }
       
        [HttpGet("")]
        public IActionResult 
    }
}
