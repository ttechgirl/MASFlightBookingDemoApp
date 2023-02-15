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
            if(model == null)
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
                BookedDate = model.BookedDate,
                FlightTime = model.FlightTime,
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
                BookedDate = entity.BookedDate,
                FlightTime = entity.FlightTime,
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

        //public static AirlineViewModel Map(this MASFlightBookingModel model)
        //{
        //    if (model == null)
        //    {
        //        return null;
        //    }
        //    return new AirlineViewModel
        //    {

        //    };

        //}

        //public static MASFlightBookingModel Map1(this AirlineViewModel entity)
        //{
        //    if (entity == null)
        //    {
        //        return null;
        //    }
        //    return new MASFlightBookingModel
        //    {

        //    };

        //}

        public static MASFlightBookingViewModel Map(this MASFlightBookingModel model)
        {
            if (model == null)
            {
                return null;
            }
            return new MASFlightBookingViewModel
            {
                PassangerInfo = model.PassangerInfo,
                Departure = model.Departure,
                Destination = model.Destination,
                TripType = model.TripType,
                BookedDate = model.BookedDate,
                FlightTime = model.FlightTime,

            };

        }

        public static MASFlightBookingModel Map(this MASFlightBookingViewModel entity)
        {
            if (entity == null)
            {
                return null;
            }
            return new MASFlightBookingModel
            {
                PassangerInfo = entity.PassangerInfo,
                Departure = entity.Departure,
                Destination = entity.Destination,
                TripType = entity.TripType,
                BookedDate = entity.BookedDate,
                FlightTime = entity.FlightTime,

            };

        }


        //public static FlightCategoryViewModel Mapp3(this MASFlightBookingModel model)
        //{
        //    if (model == null)
        //    {
        //        return null;
        //    }
        //    return new FlightCategoryViewModel
        //    {
        //        FlightCategory = 


        //    };

        //}

        //public static MASFlightBookingModel Map3(this FlightCategoryViewModel entity)
        //{
        //    if (entity == null)
        //    {
        //        return null;
        //    }
        //    return new MASFlightBookingModel
        //    {

        //    };

        //}


        //public static PassangerInfoViewModel Mapp4(this MASFlightBookingModel model)
        //{
        //    if (model == null)
        //    {
        //        return null;
        //    }
        //    return new PassangerInfoViewModel
        //    {
        //        Name = model.Name,
        //        PhoneNumber = model.PhoneNumber,
        //        Email = model.Email,
        //        Address = model.Address,
        //        MaturityLevel = model.MaturityLevel
        //    };

        //}

        //public static MASFlightBookingModel Map4(this PassangerInfoViewModel entity)
        //{
        //    if (entity == null)
        //    {
        //        return null;
        //    }
        //    return new MASFlightBookingModel
        //    {
        //        PassangerInfo = entity.Name,
        //    };

        //}



        //public static NextOfKin Map(this NextOfKinDto model)
        //{
        //    if (model == null)
        //    {
        //        return null;
        //    }
        //    //return new PassangerDetails
        //    //{
        //    //    Id = model.Id,
        //    //    Name = model.Name,
        //    //    PhoneNumber = model.PhoneNumber,
        //    //    Address = model.Address,
        //    //    // NextofKin = new NextofKin
        //    //    NextOfKinId = model.NextOfKinId,
        //    //    MaturityLevel = model.MaturityLevel
        //    //};

        //}

    }
}

