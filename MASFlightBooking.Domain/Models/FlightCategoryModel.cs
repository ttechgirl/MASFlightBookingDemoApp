using MASFlightBooking.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MASFlightBooking.Domain.Models
{
    public class FlightCategoryModel : BaseEntity
    {
        public Status Status { get; set; }
        public decimal? AmountPerSeat { get; set; }
        public FlightCategory FlightCategory { get; set; }
        
    }
}
