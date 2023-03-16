using MASFlightBooking.DataAccess.Dtos;
using MASFlightBooking.Domain.ViewModels;
using MASFlightBookingWebApp.Concrete.Interface;
using Newtonsoft.Json;

namespace MASFlightBookingWebApp.Concrete.Service
{
    public class AirlineService : IAirlineService
    {
        HttpClient client = new HttpClient();
        private readonly IConfiguration configuration;
        public AirlineService(IConfiguration configuration)
        {
            this.configuration = configuration;

        }

        public async Task<IEnumerable<AirlineViewModel>> GetAllAirlines()
        {
            var url = configuration.GetValue<string>("API:url");
            IEnumerable<AirlineViewModel> airline = new List<AirlineViewModel>();
            client.BaseAddress = new Uri(url + "api/Airline/");

            var request = await client.GetAsync("GetAirlines");
            
            var response = await request.Content.ReadAsStringAsync();
            airline = JsonConvert.DeserializeObject<List<AirlineViewModel>>(response);

            return airline;
        }

        public Task<AirlineViewModel> GetSingleAirline(Guid Id)
        {
            throw new NotImplementedException();
        }
    }
}


