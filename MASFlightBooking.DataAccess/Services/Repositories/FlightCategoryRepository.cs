using MASFlightBooking.DataAccess.Dtos;
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
    public class FlightCategoryRepository : IFlightCategory
    {
        private MASFlightDbContext _appflightDbContext;

        public FlightCategoryRepository(MASFlightDbContext appflightDbcontext)
        {
            _appflightDbContext = appflightDbcontext;
        }


        public async Task<IEnumerable<FlightCategoryDto>> GetAllCategory()
        {
            var list = await _appflightDbContext.FlightCategories.ToListAsync();
            return list.Select(x => x.Map());

        }

        public async Task<FlightCategoryDto> GetSingleCategory(Guid Id)
        {
            var list = await _appflightDbContext.FlightCategories.FindAsync(Id);
            if (list == null)
            {
                return null;
            }
            return list.Map();
        
        }

        public async  Task<bool> AddCategory(FlightCategoryViewModel model)
        {
            var category = new FlightCategoryModel()
            {
                Status = model.Status,
                CategoryName = model.CategoryName,
                FlightCategory = model.Category,
                AmountPerSeat= model.AmountPerSeat,
                CreatedBy = "Admin",
                CreatedOn = DateTime.Now

            };

            var create = await _appflightDbContext.FlightCategories.AddAsync(category);
            if (create == null)
            {
                return false;

            }

            await _appflightDbContext.SaveChangesAsync();
            return true;

        }

        public async Task<bool> UpdateCategory(FlightCategoryViewModel model)
        {
            var create = await _appflightDbContext.FlightCategories.FirstOrDefaultAsync(x =>x.Id ==model.Id);

            if (create == null)
            {
                return false;
            }
            create.CategoryName = model.CategoryName;
            create.AmountPerSeat = model.AmountPerSeat;
            create.ModifiedOn = DateTime.Now;
            create.ModifiedBy = "Admin";
            create.FlightCategory = model.Category;
            create.Status = model.Status;

            _appflightDbContext.FlightCategories.Update(create);
            await _appflightDbContext.SaveChangesAsync();

            return true;
        }
        public void DeleteCategory(Guid Id)
        {
            var list = _appflightDbContext.FlightCategories.FirstOrDefault(x => x.Id == Id);
            if (list != null)
            {
                _appflightDbContext.Remove(list);
                _appflightDbContext.SaveChanges();
            }
        }
       
    }
}
