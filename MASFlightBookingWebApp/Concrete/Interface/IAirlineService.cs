using MASFlightBooking.Domain.ViewModels;

namespace MASFlightBookingWebApp.Concrete.Interface
{
    public interface IAirlineService
    {
        Task<IEnumerable<AirlineViewModel>> GetAllAirlines();
        Task<AirlineViewModel> GetSingleAirline(Guid Id);
    }
}
