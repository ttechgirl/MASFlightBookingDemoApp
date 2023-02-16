using MASFlightBooking.Domain.Enums;
using MASFlightBooking.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MASFlightBooking.Domain.Models
{
    public class PassangerInfoModel : BaseEntity
    {
        public string? Name { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public Guid NextOfKinId { get; set; }
        public NextOfKin? NextOfKin { get; set; }
        public TravelerAge MaturityLevel{ get; set; }

       
    }



    public class NextOfKin : BaseEntity 
    {
        public string? Name { get; set; }
        public string? Relationhsip { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }



    }

}
