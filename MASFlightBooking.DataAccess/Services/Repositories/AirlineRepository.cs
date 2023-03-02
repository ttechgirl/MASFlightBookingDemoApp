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
    public class AirlineRepository : IAirline
    {

        private MASFlightDbContext _appflightDbContext;
        
        public AirlineRepository(MASFlightDbContext appflightDbContext)
        {
             _appflightDbContext = appflightDbContext;
        }




        public async Task<IEnumerable<AirlinesDto>> GetAllAirlines()
        {
           var list = await _appflightDbContext.Airlines.ToListAsync();
            return list.Select(x=>x.Map());
        }

        public async Task<AirlinesDto> GetSingleAirline(Guid Id)
        {
           var list = await _appflightDbContext.Airlines.FindAsync(Id);
            if(list == null)
            {
                return null;
            }
            return list.Map();

        }

        public async Task<bool> AddAirline(AirlineViewModel model)
        {
            //var conv = (AirlineModel)model;
            var airlines = new AirlineModel()
            {
                Id = model.Id,
                Airline = model.Airline,
                AirlineName = model.AirlineName,
                Status = model.Status,
                ModifiedOn = DateTime.Now,
                ModifiedBy = "Admin"


            };
            var create = await _appflightDbContext.Airlines.AddAsync(airlines);
            if (create == null)
            {
                return false;

            }
            await _appflightDbContext.SaveChangesAsync();
            return true;

        }



        public async Task<bool> UpdateAirline(AirlineViewModel model)
        {
            var create = await _appflightDbContext.Airlines.FirstOrDefaultAsync(x => x.Id == model.Id);



            if (create == null)
            {
                return false;
            }
            create.Airline = model.Airline;
            create.AirlineName = model.AirlineName;
            create.Status = model.Status;
            create.ModifiedOn = DateTime.Now;
            create.ModifiedBy = "Admin";

            _appflightDbContext.Airlines.Update(create);
            await _appflightDbContext.SaveChangesAsync();

            return true;
            
        }

        public void DeleteAirline(Guid Id)
        {
           var existAirline = _appflightDbContext.Airlines.FirstOrDefault(x =>x.Id == Id);
            if (existAirline != null)
            {
                _appflightDbContext.Remove(existAirline);
                _appflightDbContext.SaveChanges();


            }
        }
    }
}
