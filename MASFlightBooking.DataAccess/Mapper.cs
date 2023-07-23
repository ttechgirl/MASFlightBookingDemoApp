using MASFlightBooking.DataAccess.Dtos;
using MASFlightBooking.Domain.Models;
using MASFlightBooking.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MASFlightBooking.DataAccess
{
    public static class Mapper
    {
        public static MASFlightBookingModel Map(this MASFlightBookingDto model)
        {
            if (model == null)
            {
                return null;
            }
            return new MASFlightBookingModel
            {
                Id = model.Id,
                PassangerInfo = model.PassangerInfo,
                PassangerInfoId = model.PassangerInfoId,
                AirlineId = model.AirlineId,
                Departure = model.Departure,
                Destination = model.Destination,
                FlightCategoryId = model.FlightCategoryId,
                TripType = model.TripType,
                //BookedDate = model.BookedDate,
                FlightDate = model.FlightDate,
                TotalCost = model.TotalCost,
            };
        }

        public static MASFlightBookingDto Map(this MASFlightBookingModel entity)
        {
            if (entity == null)
            {
                return null;
            }
            return new MASFlightBookingDto
            {
                Id = entity.Id,
                PassangerInfo = entity.PassangerInfo,
                PassangerInfoId = entity.PassangerInfoId,
                AirlineId = entity.AirlineId,
                Departure = entity.Departure,
                Destination = entity.Destination,
                FlightCategoryId = entity.FlightCategoryId,
                TripType = entity.TripType,
                //BookedDate = entity.BookedDate,
                FlightDate = entity.FlightDate,
                TotalCost = entity.TotalCost,

            };

        }

        public static PassangerInfoModel Map(this PassangerDetailsDto model)
        {
            if (model == null)
            {
                return null;
            }
            return new PassangerInfoModel
            {
                Id = model.Id,
                Name = model.Name,
                PhoneNumber = model.PhoneNumber,
                Email = model.Email,
                Address = model.Address,
                // NextofKin = new NextofKin
                NextOfKinId = model.NextOfKinId,
                MaturityLevel = model.MaturityLevel
            };

        }

        public static PassangerDetailsDto Map(this PassangerInfoModel entity)
        {
            if (entity == null)
            {
                return null;
            }
            return new PassangerDetailsDto
            {
                Id = entity.Id,
                Name = entity.Name,
                PhoneNumber = entity.PhoneNumber,
                Email = entity.Email,
                Address = entity.Address,
                // NextofKin = new NextofKin
                NextOfKinId = entity.NextOfKinId,
                MaturityLevel = entity.MaturityLevel
            };

        }

        public static AirlineModel Map(this AirlinesDto model)
        {
            if (model == null)
            {
                return null;
            }
            return new AirlineModel
            {
                Id = model.Id,
                Status = model.Status,
                Airline = model.Airline,
                AirlineName = model.AirlineName,
               
            };

        }

        public static AirlinesDto Map(this AirlineModel model)
        {
            if (model == null)
            {
                return null;
            }
            return new AirlinesDto
            {
                Id = model.Id,
                Status = model.Status,
                Airline = model.Airline,
                AirlineName = model.AirlineName,

            };

        }

        public static FlightCategoryModel Map(this FlightCategoryDto model)
        {
            if (model == null)
            {
                return null;
            }
            return new FlightCategoryModel
            {
                Id = model.Id,
                Status = model.Status,
                FlightCategory = model.Category,
                CategoryName = model.CategoryName

            };

        }

        public static FlightCategoryDto Map(this FlightCategoryModel model)
        {
            if (model == null)
            {
                return null;
            }
            return new FlightCategoryDto
            {
                Id = model.Id,
                Status = model.Status,
                Category = model.FlightCategory,
                CategoryName = model.CategoryName

            };

        }
    }
       
}

