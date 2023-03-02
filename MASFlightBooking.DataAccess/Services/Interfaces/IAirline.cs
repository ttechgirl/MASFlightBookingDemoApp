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
    public interface IAirline
    {
        Task<IEnumerable<AirlinesDto>> GetAllAirlines();
        Task<AirlinesDto> GetSingleAirline(Guid Id);
        Task<bool> AddAirline(AirlineViewModel model);
        Task<bool> UpdateAirline(AirlineViewModel model);
        void DeleteAirline(Guid Id);
    }
}
