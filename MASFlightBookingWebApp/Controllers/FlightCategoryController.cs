using MASFlightBooking.Domain.ViewModels;
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
            var url = configuration.GetValue<string>("API:url");
            IEnumerable<FlightCategoryViewModel> category = new List<FlightCategoryViewModel>();
            client.BaseAddress = new Uri(url + "api/FlightCategory/");

            var request = await client.GetAsync("GetCategory");
            if (!ModelState.IsValid)
            {

                category = Enumerable.Empty<FlightCategoryViewModel>();
                ModelState.AddModelError(string.Empty, "Flight category not found");
                return View(request);

            }
            var response = await request.Content.ReadAsStringAsync();
            category = JsonConvert.DeserializeObject<List<FlightCategoryViewModel>>(response);
            return View(category);
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
