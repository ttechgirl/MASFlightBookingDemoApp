using MASFlightBooking.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MASFlightBooking.Domain.ViewModels
{
    public class MASFlightViewModel
    {
        public string? TicketName { get; set; }
        public int Number_of_passanger { get; set; }
        public Airline Airline { get; set; }
        public Departure Departure { get; set; }
        public Destination Destination { get; set; }
        public FlightCategories FlightCategories { get; set; }
        public TravelerAge TravelerAge { get; set; }
        public TripType TripType { get; set; }
    }
}
