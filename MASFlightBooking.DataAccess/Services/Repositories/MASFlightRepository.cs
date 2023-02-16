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
        private readonly IPaymentInterface _paymentInterface;

        public MASFlightRepository(MASFlightDbContext flightDbContext, IPaymentInterface paymentInterface)
        {
            _appflightDbContext = flightDbContext;
            _paymentInterface = paymentInterface;
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

        

        public async Task<MASFlightBookingViewModel> CreateBooking(CreateBookingViewModel model)
        {

            if (model == null)
            {
                return null;
            }
            
            var rand = new Random();
            int tranId = rand.Next(1000);
            var tx_ref = $"Flight-{tranId}-{DateTime.Now}";

            var sendPaymentData = new PaymentRequestModel()
            {
                    
                redirect_url = "http://localhost:4001",
                tx_ref = tx_ref,
                amount = 40000,
                currency = "NGN",
                payment_options = "card",
                customer = new Customer()
                {
                    email = model.PassangerInfo.Email,
                    name = model.PassangerInfo.Name,
                    phonenumber = model.PassangerInfo.PhoneNumber

                },

            };
                
            var request = await _paymentInterface.InitiatePayment(sendPaymentData);

            var response = (MASFlightBookingViewModel)model;
            model.Message = request.data.link;
            var buyTicket = (MASFlightBookingModel)model;


            await _appflightDbContext.MASFlights.AddAsync(buyTicket);

            await _appflightDbContext.SaveChangesAsync();


            return response;

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
