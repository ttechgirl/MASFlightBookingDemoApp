using MASFlightBooking.Domain.ViewModels;
using MASFlightBookingWebApp.Concrete.Interface;
using Newtonsoft.Json;

namespace MASFlightBookingWebApp.Concrete.Service
{
    public class FlightCategoryService : IFlightCategoryService
    {
        private readonly IConfiguration configuration;
        HttpClient client = new HttpClient();

        public FlightCategoryService(IConfiguration configuration)
        {
            this.configuration = configuration; 
        }
        public async Task<IEnumerable<FlightCategoryViewModel>> GetAllCategories()
        {
            var url = configuration.GetValue<string>("API:url");
            IEnumerable<FlightCategoryViewModel> category = new List<FlightCategoryViewModel>();
            client.BaseAddress = new Uri(url + "api/FlightCategory/");

            var request = await client.GetAsync("GetCategory");
           
            var response = await request.Content.ReadAsStringAsync();
            category = JsonConvert.DeserializeObject<List<FlightCategoryViewModel>>(response);
            return category;
        }

        //public async  Task<FlightCategoryViewModel> GetSingleCategory(Guid Id)
        //{
        //    var url = configuration.GetValue<string>("API:url");
        //    client.BaseAddress = new Uri(url);
        //    var request = await client.GetAsync($"api/FlightCategory/{Id}");
        //    var response = await request.Content.ReadAsStringAsync();
        //    var category = JsonConvert.DeserializeObject<FlightCategoryViewModel>(response);
        //    return category;
        //}
    }
}
