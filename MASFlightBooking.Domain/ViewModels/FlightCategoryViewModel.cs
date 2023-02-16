using MASFlightBooking.Domain.Enums;
using MASFlightBooking.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MASFlightBooking.Domain.ViewModels
{
    public class FlightCategoryViewModel
    {
        public Status Status { get; set; }
        public FlightCategory FlightCategory { get; set; }



        public static explicit operator FlightCategoryViewModel(FlightCategoryModel source)
        {
            var destination = new FlightCategoryViewModel();
            destination.Status = source.Status;
            destination.FlightCategory = source.FlightCategory;
            
            return destination;
        }


        public static explicit operator FlightCategoryModel(FlightCategoryViewModel source)
        {
            var destination = new FlightCategoryModel();
            destination.Status = source.Status;
            destination.FlightCategory = source.FlightCategory;

            return destination;



        }

    }
}
