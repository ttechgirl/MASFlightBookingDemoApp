using MASFlightBooking.Domain.Enums;
using MASFlightBooking.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MASFlightBooking.Domain.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder builder)
        {
            builder.Entity<MASFlightBookingModel>().HasData(
                new MASFlightBookingModel
                {
                    Id = Guid.NewGuid(),
                    TicketName = "Akeem",
                    Number_of_passanger = 2,
                    Airline =(int)Airline.IRS,
                    UpdatedOn = DateTime.Now,

                });
        
        
        
        
        
        
        }

    }
}
