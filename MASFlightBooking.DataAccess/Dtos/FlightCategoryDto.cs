using MASFlightBooking.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MASFlightBooking.DataAccess.Dtos
{
    public class FlightCategoryDto
    {
        public Guid Id { get; set; }
        public Status Status { get; set; }
        public double? AmountPerSeat { get; set; }
        public FlightCategory Category { get; set; }
        public string? CategoryName { get; set; }

    }
}
