using MASFlightBooking.DataAccess.Services.Interfaces;
using MASFlightBooking.Domain.Context;
using MASFlightBooking.Domain.Models;
using MASFlightBooking.Domain.Models.Payments;
using MASFlightBooking.Domain.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MASFlightBooking.DataAccess.Services.Repositories
{
    public class MASFlightRepository : IMASFlightInterface
    {
        private MASFlightDbContext _appflightDbContext;
        public MASFlightRepository(MASFlightDbContext flightDbContext)
        {
            _appflightDbContext = flightDbContext;
        }

        public async Task<IEnumerable<MASFlightBookingModel>> GetAllFlight()
        {
            // return await _appflightDbContext.Set<MASFlightBookingModel>().ToListAsync();
            var allflight = await _appflightDbContext.MASFlights.ToListAsync();
            return allflight;
            
        }

        public async Task<MASFlightBookingModel> GetSingleFlight(Guid Id)
        {
            return await _appflightDbContext.MASFlights.FirstOrDefaultAsync(b => b.Id == Id);

        }

        public async Task<MASFlightBookingModel> BuyFlight_Ticket(MASFlightBookingModel masflight)
        {

            var result =  _appflightDbContext.Set<MASFlightBookingModel>().Add(masflight);
            await _appflightDbContext.SaveChangesAsync();
            return result.Entity;


            var buyTicket = new MASFlightBookingModel()
            {
                TicketName = masflight.TicketName,
                Number_of_Passanger = masflight.Number_of_Passanger,
                Destination = masflight.Destination,
                Departure = masflight.Departure,
                TripType = masflight.TripType,
                FlightCategories = masflight.FlightCategories,
                TravelersAge = masflight.TravelersAge,
                Airline = masflight.Airline

            };



          

           
        }

        public Task<MASFlightBookingModel> UpdateFlight_Details(MASFlightBookingModel masflight)
        {
            throw new NotImplementedException();
        }

        public void Revoke_Flight(long BookingId)
        {
            throw new NotImplementedException();
        }

        public Task<MASFlightBookingModel> CreateBooking(MASFlightViewModel model)
        {
            throw new NotImplementedException();
        }

       
    }
}
