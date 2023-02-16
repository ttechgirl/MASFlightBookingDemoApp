using MASFlightBooking.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MASFlightBooking.Domain.Models
{
    public class AirlineModel : BaseEntity
    {

        public Status Status { get; set; }
        public string? AirlineName { get; set;}
        public Airlines Airline { get; set; }

    }
}
