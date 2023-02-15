using MASFlightBooking.DataAccess.Dtos;
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

        public async Task<IEnumerable<MASFlightBookingDto>> GetAllFlight()
        {
            var allFlight = await _appflightDbContext.MASFlights
                .Include(p=>p.PassangerInfo)
                .ToListAsync();
            return allFlight.Select(x=>x.Map()); 
            
        }

        public async Task<MASFlightBookingDto> GetSingleFlight(Guid Id)
        {
            var flight = await _appflightDbContext.MASFlights
                .Include(p=> p.PassangerInfo)
                .FirstOrDefaultAsync(x=> x.Id == Id);
            if (flight == null) 
            {
                return null;
            }
            return flight.Map();

        }

        

        public Task<MASFlightBookingViewModel> CreateBooking(MASFlightBookingModel model)
        {
            var flight = model.Mapp2();
            var result =  _appflightDbContext.MASFlights.AddAsync(flight);
            await _appflightDbContext.SaveChangesAsync();


            var buyTicket = new MASFlightBookingModel()
            {
                //TicketName = masflight.TicketName,
                //Number_of_Passanger = masflight.Number_of_Passanger,
                //Destination = masflight.Destination,
                //Departure = masflight.Departure,
                //TripType = masflight.TripType,
                //FlightCategories = masflight.FlightCategories,
                //TravelersAge = masflight.TravelersAge,
                //Airline = masflight.Airline

            };
            return result

            throw new NotImplementedException();
        }

        public Task<MASFlightBookingViewModel> UpdateFlight(MASFlightBookingViewModel masflight)
        {
            throw new NotImplementedException();
        }

        public void Revoke_Flight(Guid Id)
        {
            throw new NotImplementedException();
        }
    }
}
