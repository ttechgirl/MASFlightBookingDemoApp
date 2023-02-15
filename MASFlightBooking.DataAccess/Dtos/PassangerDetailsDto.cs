using MASFlightBooking.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MASFlightBooking.DataAccess.Dtos
{
    public class PassangerDetailsDto
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public NextofKin? NextofKin { get; set; }
        public Guid NextOfKinId { get; set; }
        public TravelerAge MaturityLevel { get; set; }


    }



    public class NextofKin 
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Relationhsip { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }



    }
}

