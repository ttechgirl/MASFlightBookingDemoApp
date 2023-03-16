using MASFlightBooking.Domain.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MASFlightBookingWebApp.Controllers
{
    public class AirlineController : Controller
    {

       /// string url = "https://localhost:7113/";
        HttpClient client = new HttpClient();
        private readonly IConfiguration configuration;
        public AirlineController(IConfiguration configuration)
        {
            this.configuration = configuration;
          
        }
        public async Task<IActionResult> Index()
        {
            var url = configuration.GetValue<string>("API:url");
            IEnumerable<AirlineViewModel> airline = new List<AirlineViewModel>();
            client.BaseAddress = new Uri(url + "api/Airline/");

            var request = await client.GetAsync("GetAirlines");
            if (!ModelState.IsValid)
            {

                airline = Enumerable.Empty<AirlineViewModel>();
                ModelState.AddModelError(string.Empty, "Airline not found");
                return View(request);

            }
            var response = await request.Content.ReadAsStringAsync();
            airline = JsonConvert.DeserializeObject<List<AirlineViewModel>>(response);
            return View(airline);
        }

        public async Task<IActionResult> GetDetails(Guid Id)
        {
            var url = configuration.GetValue<string>("API:url");
            client.BaseAddress = new Uri(url);
            var request = await client.GetAsync($"api/Airline/{Id}");
            var response = await request.Content.ReadAsStringAsync();
            var airline = JsonConvert.DeserializeObject<AirlineViewModel>(response);
            return View(airline);

        }


    }
}
