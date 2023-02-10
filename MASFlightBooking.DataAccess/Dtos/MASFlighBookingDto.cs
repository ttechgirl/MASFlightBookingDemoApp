using MASFlightBooking.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MASFlightBooking.DataAccess.Dtos
{
    public class MASFlighBookingDto
    {
        public string? TicketName { get; set; }
        public int Number_of_passanger { get; set; }
        public int Airline { get; set; }
        public int Departure { get; set; }
        public int Destination { get; set; }
        public int FlightCategories { get; set; }
        public int TravelerAge { get; set; }
        public int TripType { get; set; }
        public DateTime UpdatedOn { get; set; }
        public string? UserName { get; set; }
        public string? PhoneNumber { get; set; }



        //public virtual ICollection<BookedFlight> Flights { get; set; }
    }
}
