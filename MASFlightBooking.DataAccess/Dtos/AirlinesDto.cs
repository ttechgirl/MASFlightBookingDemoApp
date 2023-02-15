using MASFlightBooking.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MASFlightBooking.DataAccess.Dtos
{
    public class AirlinesDto 
    {
        public Guid Id { get; set; }
        public Status Status { get; set; }
        public string? AirlineName { get; set; }
    
    }

        

    
}
