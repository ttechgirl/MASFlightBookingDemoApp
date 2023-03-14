using MASFlightBooking.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MASFlightBooking.Domain.Models
{
    public class MASFlightBookingModel : BaseEntity
    {
        public DateTime BookedDate { get;}
        public DateTime FlightDate { get; set; }
        public decimal TotalCost { get; set; }
        public Departure Departure { get; set; }
        public Destination Destination { get; set; }
        public TripType TripType { get; set; }

        //[ForeignKey("PassangerInfo")]
        public Guid PassangerInfoId { get; set; }
        public PassangerInfoModel? PassangerInfo { get; set; }

        //[ForeignKey("FlightCategory")]
        public Guid FlightCategoryId { get; set; }
        public FlightCategoryModel? FlightCategory { get; set; }

        //[ForeignKey("Airline")]
        public Guid AirlineId { get; set; }
        public AirlineModel? Airline{ get; set; }

        

        //public int NumberOfPassanger { get; set; }
        //collection for multiple passangers 

    }

   






}
