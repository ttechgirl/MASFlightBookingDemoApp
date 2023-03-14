using MASFlightBooking.Domain.Enums;
using MASFlightBooking.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MASFlightBooking.Domain.ViewModels
{
    public class MASFlightBookingViewModel 
    {
        public PassangerInfoViewModel? PassangerInfo { get; set; }
        public NextOfKinViewModel? NextOfKin { get; set;}
        public DateTime BookedDate { get; }
        public DateTime FlightDate { get; set; }
        public Departure Departure { get; set; }
        public Destination Destination { get; set; }
        public TripType TripType { get; set; }
        public string? PaymentUrl { get; set; }
        

        //explicit conversion
        public static explicit operator MASFlightBookingViewModel(MASFlightBookingModel source)
        {
            var destination = new MASFlightBookingViewModel();
            destination.PassangerInfo = (PassangerInfoViewModel?)source.PassangerInfo;
            destination.NextOfKin = (NextOfKinViewModel?)source.PassangerInfo.NextOfKin;
           // destination.BookedDate = source.BookedDate;
            destination.FlightDate = source.FlightDate;
            destination.Departure = source.Departure;
            destination.Destination = source.Destination;
            destination.TripType = source.TripType; 
            return destination;
        }


        public static explicit operator MASFlightBookingModel(MASFlightBookingViewModel source)
        {
            var destination = new MASFlightBookingModel();
            destination.PassangerInfo = (PassangerInfoModel?)source.PassangerInfo;
            destination.PassangerInfo.NextOfKin = (NextOfKin?)source.NextOfKin;
            //destination.BookedDate = source.BookedDate;
            destination.FlightDate = source.FlightDate;
            destination.Departure = source.Departure;
            destination.Destination = source.Destination;
            destination.TripType = source.TripType;
            return destination;
        }

        
    }

    public class CreateBookingViewModel 
    {
        //[HiddenInput(DisplayValue = false)]
        public Guid Id { get; set; }
        public PassangerInfoViewModel? PassangerInfo { get; set; }
        public NextOfKinViewModel? NextOfKin { get; set; }
        public DateTime BookedDate { get; }
        public DateTime FlightDate { get; set; }
        public Departure Departure { get; set; }
        public Destination Destination { get; set; }
        public TripType TripType { get; set; }
        public Guid AirlineId { get; set; }
        public Guid FlightCategoryId { get; set; }
        

        //explicit conversion
        public static explicit operator CreateBookingViewModel(MASFlightBookingModel source)
        {
            var destination = new CreateBookingViewModel();
            destination.Id = source.Id;
            destination.PassangerInfo = (PassangerInfoViewModel?)source.PassangerInfo;
            //destination.BookedDate = source.BookedDate;
            destination.FlightDate = source.FlightDate;
            destination.Departure = source.Departure;
            destination.Destination = source.Destination;
            destination.TripType = source.TripType;
           
            return destination;
        }

        public static explicit operator MASFlightBookingModel(CreateBookingViewModel source)
        {
            var destination = new MASFlightBookingModel();
            destination.Id = source.Id;
            destination.PassangerInfo = (PassangerInfoModel?)source.PassangerInfo;
            //destination.BookedDate = source.BookedDate;
            destination.FlightDate = source.FlightDate;
            destination.Departure = source.Departure;
            destination.Destination = source.Destination;
            destination.TripType = source.TripType;
            destination.AirlineId = source.AirlineId;
            destination.FlightCategoryId = source.FlightCategoryId;
            return destination;
        }

        public static explicit operator MASFlightBookingViewModel(CreateBookingViewModel source)
        {
            var destination = new MASFlightBookingViewModel();
            destination.PassangerInfo = source.PassangerInfo;
            //destination.BookedDate = source.BookedDate;
            destination.FlightDate = source.FlightDate;
            destination.Departure = source.Departure;
            destination.Destination = source.Destination;
            destination.TripType = source.TripType;

            return destination;
        }

        public static explicit operator CreateBookingViewModel(MASFlightBookingViewModel source)
        {
            var destination = new CreateBookingViewModel();
            destination.PassangerInfo = source.PassangerInfo;
           // destination.BookedDate = source.BookedDate;
            destination.FlightDate = source.FlightDate;
            destination.Departure = source.Departure;
            destination.Destination = source.Destination;
            destination.TripType = source.TripType;
            return destination;
        }
    }
}
