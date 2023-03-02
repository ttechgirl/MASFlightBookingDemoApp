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
        public Guid Id { get; set; }
        public Status Status { get; set; }
        public double? AmountPerSeat { get; set; }
        public FlightCategory Category { get; set; }
        public string? CategoryName { get; set; }



        public static explicit operator FlightCategoryViewModel(FlightCategoryModel source)
        {
            var destination = new FlightCategoryViewModel();
            destination.Status = source.Status;
            destination.AmountPerSeat = source.AmountPerSeat;
            destination.CategoryName = source.CategoryName;
            destination.Category = source.FlightCategory;
            
            return destination;
        }


        public static explicit operator FlightCategoryModel(FlightCategoryViewModel source)
        {
            var destination = new FlightCategoryModel();
            destination.Status = source.Status;
            destination.AmountPerSeat = source.AmountPerSeat;
            destination.CategoryName = source.CategoryName;
            destination.FlightCategory = source.Category;

            return destination;



        }

    }
}
