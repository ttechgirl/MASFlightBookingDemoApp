using MASFlightBooking.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MASFlightBooking.Domain.ViewModels
{
    public class AirlineViewModel
    {
        public Airline Airline { get; set; }
        public Status Status { get; set; }

    }
}
