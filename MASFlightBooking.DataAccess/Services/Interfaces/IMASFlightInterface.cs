using MASFlightBooking.Domain.Models;
using MASFlightBooking.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MASFlightBooking.DataAccess.Services.Interfaces
{
    public interface IMASFlightInterface
    {
        Task<IEnumerable<MASFlightBookingModel>> GetALLFlight();
        Task<MASFlightBookingModel> GetMASFlights(Guid Id);
        Task<MASFlightBookingModel> BuyFlight_Ticket(MASFlightBookingModel masflight);
        Task<MASFlightBookingModel> UpdateFlight_Details(MASFlightBookingModel masflight);
        void Revoke_Flight(long BookingId);
    }
}
