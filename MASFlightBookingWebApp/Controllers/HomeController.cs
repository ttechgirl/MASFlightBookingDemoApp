using MASFlightBooking.DataAccess.Dtos;
using MASFlightBooking.Domain.ViewModels;
using MASFlightBookingWebApp.Concrete.Interface;
using MASFlightBookingWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Dynamic;
using System.Net.Http.Headers;
using System.Text;

namespace MASFlightBookingWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration configuration;
        private readonly IAirlineService airlineService;
        private readonly IFlightCategoryService categoryService;

        // string url = "https://localhost:7113/";
        HttpClient client = new HttpClient();

        public HomeController(ILogger<HomeController> logger, IConfiguration configuration, IAirlineService airlineService ,IFlightCategoryService categoryService)
        {
            _logger = logger;
            this.configuration = configuration;
            this.airlineService = airlineService;
            this.categoryService = categoryService; 
        }

        //GetAllFlights
        public async Task<IActionResult> Index()
        {
            var url = configuration.GetValue<string>("API:url");

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
            var url = configuration.GetValue<string>("API:url");
            client.BaseAddress = new Uri(url);
            var request = await client.GetAsync($"api/MASFlight/Get-Single-Flight?Id={Id}");
            var response = await request.Content.ReadAsStringAsync();
            var flight = JsonConvert.DeserializeObject<CreateBookingViewModel>(response);
            return View(flight);

        }

        public async Task<ActionResult> Create()
        {
            ViewBag.Airlines = await airlineService.GetAllAirlines();
            ViewBag.Category = await categoryService.GetAllCategories();
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create(CreateBookingViewModel model)
        {
            var url = configuration.GetValue<string>("API:url");

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

        public async Task<IActionResult> Edit(Guid Id)
        {
            ViewBag.Airlines = await airlineService.GetAllAirlines();
            ViewBag.Category = await categoryService.GetAllCategories();

            var url = configuration.GetValue<string>("API:url");

            client.BaseAddress = new Uri(url);
            var request = await client.GetAsync($"api/MASFlight/Get-Single-Flight?Id={Id}");
            var response = await request.Content.ReadAsStringAsync();
            var flight = JsonConvert.DeserializeObject<CreateBookingViewModel>(response);
            return View(flight);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(CreateBookingViewModel model)
        {
            var url = configuration.GetValue<string>("API:url");

            string data = JsonConvert.SerializeObject(model);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync(url + "api/MASFlight/Update-Flight/", content);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }

            ModelState.AddModelError(string.Empty, "Fill all details");
            return View(model);


            //var data = JsonConvert.SerializeObject(model);
            //var request = await client.PutAsync("api/MASFlight/Update-Flight", new StringContent(data, Encoding.UTF8,"application/json"));
            //var response = await request.Content.ReadAsStringAsync();

        }


        public async Task<IActionResult> Cancel(Guid Id)
        {
            var url = configuration.GetValue<string>("API:url");

            client.BaseAddress = new Uri(url);
            var request = await client.DeleteAsync($"api/MASFlight/Cancel-Flight?id={Id}");
            var response = await request.Content.ReadAsStringAsync();
            var flight = JsonConvert.DeserializeObject<CreateBookingViewModel>(response);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(Guid Id)
        {
            var url = configuration.GetValue<string>("API:url");

            client.BaseAddress = new Uri(url);
            var request = await client.GetAsync($"api/MASFlight/Get-Single-Flight?Id={Id}");
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