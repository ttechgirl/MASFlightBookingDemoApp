using MASFlightBooking.DataAccess.Dtos;
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
        Task<IEnumerable<MASFlightBookingDto>> GetAllFlight();
        Task<MASFlightBookingDto> GetSingleFlight(Guid Id);
        Task<MASFlightBookingViewModel> CreateBooking(CreateBookingViewModel model);
        Task<bool> UpdateFlight(CreateBookingViewModel masflight);
         void DeleteBooking(Guid Id);
    
    
    
    }
}
