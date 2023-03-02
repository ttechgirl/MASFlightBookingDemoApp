using MASFlightBooking.DataAccess.Dtos;
using MASFlightBooking.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MASFlightBooking.DataAccess.Services.Interfaces
{
    public interface IFlightCategory
    {
        Task<IEnumerable<FlightCategoryDto>> GetAllCategory();
        Task<FlightCategoryDto> GetSingleCategory(Guid Id);
        Task<bool> AddCategory(FlightCategoryViewModel model);
        Task<bool> UpdateCategory(FlightCategoryViewModel model);
        void DeleteCategory(Guid Id);
    }
}
