using MASFlightBooking.DataAccess.Dtos;
using MASFlightBooking.Domain.ViewModels;
using MASFlightBookingWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Text;

namespace MASFlightBookingWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        string url = "https://localhost:7113/";
        HttpClient client = new HttpClient();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        //GetAllFlights
        public async Task<IActionResult> Index()
        {
            IEnumerable<CreateBookingViewModel> flight = new List<CreateBookingViewModel>();
            client.BaseAddress = new Uri(url + "api/MASFlight/");

            var request = await client.GetAsync("GetAllFlights");
            if (!ModelState.IsValid)
            {

                flight = Enumerable.Empty<CreateBookingViewModel>();
                ModelState.AddModelError(string.Empty, "Flight details not found");
                return View(request);

            }
            var response = await request.Content.ReadAsStringAsync();
            flight = JsonConvert.DeserializeObject<List<CreateBookingViewModel>>(response);
            return View(flight);
            
        }

        public async Task<IActionResult> GetDetails(Guid Id)
        {

            client.BaseAddress = new Uri(url);
            var request = await client.GetAsync($"api/MASFlight/Get-Single-Flight?Id={Id}");
            var response = await request.Content.ReadAsStringAsync();
            var flight = JsonConvert.DeserializeObject<CreateBookingViewModel>(response);
            return View(flight);

        }

        public ActionResult Create()
        {

            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create(CreateBookingViewModel model)
        {

            client.BaseAddress = new Uri(url);
            var data = JsonConvert.SerializeObject(model);
            var request = await client.PostAsync("api/MASFlight/Book-Flight", new StringContent(data, Encoding.UTF8, "application/json"));
            var response = await request.Content.ReadAsStringAsync();
            var flight = JsonConvert.DeserializeObject<CreateBookingViewModel>(response);

            if (!request.IsSuccessStatusCode)
            {
                ModelState.AddModelError(string.Empty, "Contact support");
                return View(flight);

            }
            return RedirectToAction("Index");

        }


        //[HttpPut]
        public async Task<IActionResult> Edit(CreateBookingViewModel model)
        {
            client.BaseAddress = new Uri(url);
            var data = JsonConvert.SerializeObject(model);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var request = await client.PutAsync("api/MASFlight/Update-Flight", new StringContent(data, Encoding.UTF8));
            var response = await request.Content.ReadAsStringAsync();
            var flight = JsonConvert.DeserializeObject<CreateBookingViewModel>(response);

            if (request.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }

            ModelState.AddModelError(string.Empty, "Fill all details");
            return View(flight);
        }


        public async Task<IActionResult> Delete(Guid Id)
        {

            client.BaseAddress = new Uri(url);
            var request = await client.DeleteAsync($"api/MASFlight/Cancel-Flight?id={Id}");
            var response = await request.Content.ReadAsStringAsync();
            var flight = JsonConvert.DeserializeObject<CreateBookingViewModel>(response);
            return View(flight);

        }


        public IActionResult Privacy()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}