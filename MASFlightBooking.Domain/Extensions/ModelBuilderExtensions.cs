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
                    Id = Guid.Parse("43738933-acf0-4479-8624-0ef1bec0383d"),
                    TicketName = "Akeem Mustapha",
                    Number_of_Passanger = 1,
                    Airline =(int)Airline.IRS,
                    UpdatedOn = DateTime.Now,

                },
                 new MASFlightBookingModel
                 {
                     Id = Guid.Parse("6c7e9c5d-89ae-43d9-8f19-feb71af65e8f"),
                     TicketName = "Oluwaseyi Kolawole",
                     Number_of_Passanger = 2,
                     Airline = (int)Airline.Dana_Air,
                     UpdatedOn = DateTime.Now,

                 },
                 new MASFlightBookingModel
                 {
                      Id = Guid.Parse("923a643a-9c41-464e-9fe3-29656c34e589"),
                      TicketName = "Bolu Adefalu",
                      Number_of_Passanger = 3,
                      Airline = (int)Airline.Air_France,
                      UpdatedOn = DateTime.Now,

                 });
        
        }

    }
}
