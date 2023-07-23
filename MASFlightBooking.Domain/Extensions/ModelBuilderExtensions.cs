using MASFlightBooking.Domain.Enums;
using MASFlightBooking.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MASFlightBooking.Domain.Models.UserIdentityModel;

namespace MASFlightBooking.Domain.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static PasswordHasher<AppUsers> Hasher { get; set; } = new PasswordHasher<AppUsers>();

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
                    AirlineName = "Dana Air",
                    Airline = Airlines.Dana_Air,
                });

            builder.Entity<AirlineModel>().HasData(
               new AirlineModel
               {
                   Id = Guid.Parse("6283d2df-ca2c-4d6f-bd2d-5cf48d317345"),
                   Status = Status.Unavailable,
                   AirlineName = "Air France",
                   Airline = Airlines.Air_France,
               });

            builder.Entity<AirlineModel>().HasData(
              new AirlineModel
              {
                  Id = Guid.Parse("cae5c97e-a07c-4656-9fa9-c6b8feb19019"),
                  Status = Status.Available,
                  AirlineName = "IRS",
                  Airline = Airlines.IRS,
              });

            builder.Entity<AirlineModel>().HasData(
            new AirlineModel
            {
                Id = Guid.Parse("14cf20ec-4426-4059-960e-9c42f8b19e9e"),
                Status = Status.Available,
                AirlineName = "MAS AIr",
                Airline = Airlines.Mas_Air,

            });
            builder.Entity<AirlineModel>().HasData(
            new AirlineModel
            {
                Id = Guid.Parse("62f8ab72-f871-4add-ae73-3f9b5b22d329"),
                Status = Status.Available,
                AirlineName = "Ibom AIr",
                Airline = Airlines.Ibom_Air,

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
                    AmountPerSeat = 50000.5,
                    FlightCategory = FlightCategory.Business,
                    CategoryName = "Business"

                });

            builder.Entity<FlightCategoryModel>().HasData(
                new FlightCategoryModel
                {
                    Id = Guid.Parse("f551bb7b-617b-4e56-9a7a-54358b4b9d38"),
                    Status = Status.Available,
                    AmountPerSeat = 123000.5,
                    FlightCategory = FlightCategory.Premium,
                    CategoryName = "Premium"

                });

            builder.Entity<FlightCategoryModel>().HasData(
                 new FlightCategoryModel
                 {
                     Id = Guid.Parse("759b4322-8282-4758-8479-db06b6d4030c"),
                     Status = Status.Available,
                     AmountPerSeat = 35800.5,
                     FlightCategory = FlightCategory.Economy,
                     CategoryName = "Economy"

                 });

            builder.Entity<FlightCategoryModel>().HasData(
                new FlightCategoryModel
                {
                    Id = Guid.Parse("185337b9-474e-49ae-8eff-f8ac0e4c65f7"),
                    Status = Status.Available,
                    AmountPerSeat = 210000.5,
                    FlightCategory = FlightCategory.FirstClass,
                    CategoryName = "First Class"

                });

            //app user
            builder.Entity<AppUsers>().HasData(
           new AppUsers
           {
               Id = Guid.NewGuid(),
               FirstName = "Akeem",
               LastName = "Mustapha",
               PhoneNumber = "08055423378",
               Email = "akeem234@gmail.com",
               PasswordHash = Hasher.HashPassword(null, "AHakeem1%")

           });

            //app role
            builder.Entity<AppRoles>().HasData(
            new AppRoles
            {
                Id = Guid.Parse("69D545C8-B65E-4FFF-82AC-BCE73AC289A3"),
                Name = "User",
                NormalizedName = "User",
                ConcurrencyStamp = "1"

            });

        }
      
    }
}
