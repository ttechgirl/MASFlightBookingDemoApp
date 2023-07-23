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
        
        public async Task<ResponseViewModel> CreateBooking(CreateBookingViewModel model)
        {
            var response = new ResponseViewModel();
            
            var rand = new Random();
            int tranId = rand.Next(1000);
            var tx_ref = $"Flight-{tranId}-{DateTime.Now}";

            var sendPaymentData = new PaymentRequestModel()
            {
                redirect_url = "http://localhost:",
                tx_ref = tx_ref,
                amount = 5000,
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
            if (request.status == "Failed")
            {
                response.Success = false;
                response.Message = "Kindly contact support";
            }
            response.Success = true;
            response.Message = request.data.link;

            var buyTicket = (MASFlightBookingModel)model;

            await _appflightDbContext.MASFlights.AddAsync(buyTicket);
            await _appflightDbContext.SaveChangesAsync();

            return response;
        }

        public async Task<bool> UpdateFlight(CreateBookingViewModel model)
        {
            var existUser = await _appflightDbContext.MASFlights
                           .Include(p => p.PassangerInfo)
                            .Include(p => p.PassangerInfo.NextOfKin)
                            .FirstOrDefaultAsync(x => x.Id == model.Id);
;                          
            if (existUser == null)
            {
               return false;
            }

            //var passanger = new PassangerInfoModel()
            //{
            //    Id = existUser.PassangerInfo.Id,
            //    Name = existUser.PassangerInfo.Name,
            //    Address = existUser.PassangerInfo.Address,
            //    PhoneNumber = existUser.PassangerInfo.PhoneNumber,
            //    ModifiedOn =  DateTime.Now,
            //};

            existUser.PassangerInfo.Name = model.PassangerInfo.Name;
            existUser.PassangerInfo.PhoneNumber = model.PassangerInfo.PhoneNumber;
            existUser.PassangerInfo.Email = model.PassangerInfo.Email;
            existUser.PassangerInfo.Address = model.PassangerInfo.Address;
            existUser.PassangerInfo.ModifiedOn = DateTime.Now;
            existUser.PassangerInfo.NextOfKin.Name = model.NextOfKin.Name;
            existUser.PassangerInfo.NextOfKin.Address = model.NextOfKin.Address;
            existUser.PassangerInfo.NextOfKin.PhoneNumber = model.NextOfKin.PhoneNumber;
            existUser.PassangerInfo.NextOfKin.Relationhsip = model.NextOfKin.Relationhsip;
            existUser.PassangerInfo.NextOfKin.ModifiedOn = DateTime.Now;
            existUser.Departure = model.Departure;
            existUser.Destination = model.Destination;
            existUser.TripType = model.TripType;
            //existUser.BookedDate = model.BookedDate;
            existUser.FlightCategoryId = model.FlightCategoryId;
            existUser.AirlineId = model.AirlineId;
            existUser.FlightDate = model.FlightDate;
            existUser.ModifiedOn = DateTime.Now;

            _appflightDbContext.Update(existUser);
            await _appflightDbContext.SaveChangesAsync();
            return true;
        }


        public void DeleteBooking(Guid Id)
        {

            var existUser =  _appflightDbContext.MASFlights
                .Include(p => p.PassangerInfo)
                .FirstOrDefault(x => x.Id == Id);

            if(existUser != null)
            {
                _appflightDbContext.Remove(existUser); 
                _appflightDbContext.SaveChanges();
            }
           
        }
    }
}
