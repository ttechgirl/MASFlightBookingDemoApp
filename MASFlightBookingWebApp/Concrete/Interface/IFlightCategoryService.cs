using MASFlightBooking.Domain.ViewModels;

namespace MASFlightBookingWebApp.Concrete.Interface
{
    public interface IFlightCategoryService
    {
        Task<IEnumerable<FlightCategoryViewModel>> GetAllCategories();
        //Task<FlightCategoryViewModel> GetSingleCategory(Guid Id);
    }
}
