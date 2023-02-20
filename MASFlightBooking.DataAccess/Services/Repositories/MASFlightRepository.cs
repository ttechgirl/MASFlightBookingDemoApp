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

            //available airline validation
            if (model.AirlineId == null )
            {
                //list of errors in MASBookingViewModel
                return default;
            }
            //available flight category validation


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
            response.RedirectUrl = request.data.link;
            var buyTicket = (MASFlightBookingModel)model;


            await _appflightDbContext.MASFlights.AddAsync(buyTicket);

            await _appflightDbContext.SaveChangesAsync();


            return response;

        }

        public async Task<bool> UpdateFlight(CreateBookingViewModel masflight)
        {
            var updatedTicket = await _appflightDbContext.MASFlights
                .Include(p => p.PassangerInfo)
                .Include(q => q.PassangerInfo.NextOfKin)
                .FirstOrDefaultAsync(x => x.Id == masflight.Id);
            if (updatedTicket == null)
            {
                return false;
            }

            updatedTicket.AirlineId = masflight.AirlineId;
            updatedTicket.FlightCategoryId = masflight.FlightCategoryId;
            updatedTicket.Departure = masflight.Departure;
            updatedTicket.Destination = masflight.Destination;
            updatedTicket.TripType = masflight.TripType;
            updatedTicket.BookedDate = masflight.BookedDate;
            updatedTicket.FlightTime = masflight.FlightTime;
            updatedTicket.PassangerInfo.Name = masflight.PassangerInfo.Name;
            updatedTicket.PassangerInfo.PhoneNumber = masflight.PassangerInfo.PhoneNumber;
            updatedTicket.PassangerInfo.Email = masflight.PassangerInfo.Email;
            updatedTicket.PassangerInfo.Address = masflight.PassangerInfo.Address;
            updatedTicket.ModifiedOn = DateTime.Now;
            updatedTicket.PassangerInfo.ModifiedOn = DateTime.Now;
            updatedTicket.PassangerInfo.NextOfKin.ModifiedOn = DateTime.Now;
            updatedTicket.PassangerInfo.NextOfKin.Address = masflight.PassangerInfo.NextOfKin.Address;
            updatedTicket.PassangerInfo.NextOfKin.Name = masflight.PassangerInfo.NextOfKin.Name;
            updatedTicket.PassangerInfo.NextOfKin.PhoneNumber = masflight.PassangerInfo.NextOfKin.PhoneNumber;
            await _appflightDbContext.SaveChangesAsync();
            return true;
        }

        public void Revoke_Flight(Guid Id)
        {
            throw new NotImplementedException();
        }
    }
}
