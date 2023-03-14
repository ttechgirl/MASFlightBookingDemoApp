using MASFlightBooking.Domain.Enums;
using MASFlightBooking.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MASFlightBooking.DataAccess.Dtos
{
    public class MASFlightBookingDto
    {
        public Guid Id { get; set; }
        public PassangerInfoModel? PassangerInfo { get; set; }
        public Guid PassangerInfoId { get; set; }
        public AirlineModel? Airline { get; set; }
        public Guid AirlineId { get; set; }
        public Departure Departure { get; set; }
        public Destination Destination { get; set; }
        public FlightCategoryModel? FlightCategory { get; set; }
        public Guid FlightCategoryId { get; set; }
        public TripType TripType { get; set; }
        public DateTime BookedDate { get; }
        public DateTime FlightDate { get; set; }
        public decimal TotalCost { get; set; }




        //public virtual ICollection<BookedFlight> Flights { get; set; }
    }
}
