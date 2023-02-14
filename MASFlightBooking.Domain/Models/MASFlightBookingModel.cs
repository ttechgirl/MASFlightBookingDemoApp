using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MASFlightBooking.Domain.Models
{
    public class MASFlightBookingModel : BaseEntity
    {
        public string? TicketName { get; set; }
        public string? MobileNumber { get; set; }
        public int Number_of_Passanger { get; set; }
        public decimal? Amount_per_Seat { get; } = 40000;
        public int Airline { get; set; }
        public int Departure { get; set; }
        public int Destination { get; set; }
        public int FlightCategories { get; set; }
        public int TravelersAge { get; set; }
        public int TripType { get; set; }
        public DateTime UpdatedOn { get; set;} 

        //public virtual ICollection<BookedFlight> Flights { get; set; }


    }



   

        
    
}
