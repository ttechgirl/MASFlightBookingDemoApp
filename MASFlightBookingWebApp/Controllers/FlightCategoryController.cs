using MASFlightBooking.Domain.ViewModels;
using MASFlightBookingWebApp.Concrete.Interface;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MASFlightBookingWebApp.Controllers
{
    public class FlightCategoryController : Controller
    {
        HttpClient client = new HttpClient();
        private readonly IConfiguration configuration;
        public FlightCategoryController(IConfiguration configuration)
        {
            this.configuration = configuration;

        }
        public async Task<IActionResult> Index()
        {
            return View();
        }

        public async Task<IActionResult> GetDetails(Guid Id)
        {
            var url = configuration.GetValue<string>("API:url");
            client.BaseAddress = new Uri(url);
            var request = await client.GetAsync($"api/FlightCategory/{Id}");
            var response = await request.Content.ReadAsStringAsync();
            var category = JsonConvert.DeserializeObject<FlightCategoryViewModel>(response);
            return View(category);

        }
    }
}
