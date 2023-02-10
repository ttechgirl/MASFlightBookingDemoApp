using MASFlightBooking.DataAccess.Services.Interfaces;
using MASFlightBooking.Domain.Context;
using MASFlightBooking.Domain.Models;
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
        private readonly IPaymentInterfaces _paymentInterfaces;
        public MASFlightRepository(MASFlightDbContext flightDbContext,IPaymentInterfaces paymentInterfaces)
        {
            _appflightDbContext = flightDbContext;
            _paymentInterfaces = paymentInterfaces;
        }

        public async Task<IEnumerable<MASFlightBookingModel>> GetALLFlight()
        {
            return await _appflightDbContext.MASFlights.ToListAsync();
        }

        public async Task<MASFlightBookingModel> GetMASFlights(Guid Id)
        {
            return await _appflightDbContext.MASFlights.FirstOrDefaultAsync(b => b.Id == Id);
        }

        public Task<MASFlightBookingModel> BuyFlight_Ticket(MASFlightBookingModel masflight)
        {
            throw new NotImplementedException();
        }

        public Task<MASFlightBookingModel> UpdateFlight_Details(MASFlightBookingModel masflight)
        {
            throw new NotImplementedException();
        }

        public void Revoke_Flight(long BookingId)
        {
            throw new NotImplementedException();
        }
    }
}
