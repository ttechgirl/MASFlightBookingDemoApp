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
        private readonly IPaymentInterface _paymentInterface;

        decimal totalAmount = 0;
        decimal Amount_per_seat;
        int Number_of_Passanger;

        public MASFlightController(IMASFlightInterface masFlightInterface, IPaymentInterface paymentInterfaces)
        {
            _paymentInterface = paymentInterfaces;
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

        [HttpGet("Get_Single_Flight")]
        public async Task<IActionResult> GetSingleFlight(Guid Id)
        {
            var allflights = await _masFlightInterface.GetSingleFlight(Id);    
            if(allflights != null)
            {
                return Ok(allflights);

            }
            return NotFound(Id);

        }
        [HttpPost("Buy_Flight_Ticket")]
        public IActionResult BuyTicket(MASFlightBookingModel model)
        {

            totalAmount = Number_of_Passanger * Amount_per_seat;
            var response = new ResponseViewModel();


            var rand = new Random();
            int tranId = rand.Next(1000);
            var tx_ref = $"Flight-{tranId}-{DateTime.Now}";


            var sendPaymentData = new PaymentRequestModel()
            {
                redirect_url = "",
                tx_ref = tx_ref,
                currency = "NGN",
                amount = totalAmount,
                payment_options = "card",
                customer = new Customer()

            };
            var purchase = _masFlightInterface.CreateBooking(model);
            //if (purchase.IsCompleted == true)
            //{
            //    var request = _paymentInterface.InitiatePayment(sendPaymentData).Result;
            //    response.Success = true;
            //    response.Message = "Flight ticket successfully purchased";

            //}
            return BadRequest();




        }



    }
}
