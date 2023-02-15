using MASFlightBooking.Domain.Enums;
using MASFlightBooking.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MASFlightBooking.Domain.ViewModels
{
    public class MASFlightBookingViewModel
    {
        public PassangerInfoModel? PassangerInfo { get; set; }
        public DateTime BookedDate { get; set; }
        public DateTime FlightTime { get; set; }
        public Departure Departure { get; set; }
        public Destination Destination { get; set; }
        public TripType TripType { get; set; }

    }
}
