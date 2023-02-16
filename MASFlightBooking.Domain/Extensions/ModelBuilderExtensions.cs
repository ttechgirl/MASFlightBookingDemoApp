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
                    //foreign key
                    Id = Guid.Parse("43738933-acf0-4479-8624-0ef1bec0383d"),
                    AirlineId = Guid.Parse("6c7e9c5d-89ae-43d9-8f19-feb71af65e8f"),
                    PassangerInfoId = Guid.Parse("923a643a-9c41-464e-9fe3-29656c34e589"),
                    FlightCategoryId = Guid.Parse("73c5bcba-65b6-46a3-897f-7d67fc0480b8")

                });

            builder.Entity<AirlineModel>().HasData(
                new AirlineModel
                {
                    Id = Guid.Parse("6c7e9c5d-89ae-43d9-8f19-feb71af65e8f"),
                    Status = Status.Available,
                    AirlineName = "Dana_Air"

                });

            builder.Entity<PassangerInfoModel>().HasData(
                new PassangerInfoModel
                {
                    Id = Guid.Parse("923a643a-9c41-464e-9fe3-29656c34e589"),
                    Name = "Mustapha Akeem",
                    PhoneNumber = "08084491078",
                    Email = "ayisatabiodun@gmail.com",
                    Address = "Abule egba ",
                    MaturityLevel = TravelerAge.Adult,
                    NextOfKinId = Guid.Parse("0ffe12ec-ea61-4e47-8a5c-e753a5fe2823")

                });


            builder.Entity<NextOfKin>().HasData(
                new NextOfKin
                {
                    Id = Guid.Parse("0ffe12ec-ea61-4e47-8a5c-e753a5fe2823"),
                    Name = "Mustapha Lateefat",
                    PhoneNumber = "08084491078",
                    Address = "Abule egba "

                });
                

            builder.Entity<FlightCategoryModel>().HasData(
                new FlightCategoryModel
                {
                    Id = Guid.Parse("73c5bcba-65b6-46a3-897f-7d67fc0480b8"),
                    Status = Status.Available,
                    AmountPerSeat = 50000,
                    FlightCategory = FlightCategory.Business

                });


        }
      
    }
}
