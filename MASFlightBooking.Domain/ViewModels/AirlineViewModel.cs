using MASFlightBooking.Domain.Enums;
using MASFlightBooking.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MASFlightBooking.Domain.ViewModels
{
    public class AirlineViewModel
    {
        public Guid Id { get; set; }
        public Airlines Airline { get; set; }
        public Status Status { get; set; }
        public  string? AirlineName { get; set; }




        public static explicit operator AirlineViewModel(AirlineModel source)
        {
            var destination = new AirlineViewModel();
            destination.Status = source.Status;
            destination.Airline = source.Airline;
            destination.AirlineName = source.AirlineName;


            return destination;
        }


        public static explicit operator AirlineModel(AirlineViewModel source)
        {
            var destination = new AirlineModel();
           // destination.Id = source.Id;
            destination.Status = source.Status;
            destination.Airline = source.Airline;
            destination.AirlineName = source.AirlineName;

            return destination;


        }

    }
}
