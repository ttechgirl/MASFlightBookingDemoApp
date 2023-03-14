using MASFlightBooking.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MASFlightBooking.Domain.ViewModels
{
    public class NextOfKinViewModel
    {
        [DisplayName("NextOfKin Name")]
        public string? Name { get; set; }
        [DisplayName("NextOfKin Relationship")]
        public string? Relationhsip { get; set; }
        [DisplayName("NextOfKin PhoneNumber")]
        public string? PhoneNumber { get; set; }
        [DisplayName("NextOfKin Address")]
        public string? Address { get; set; }



        //explicit conversion
        public static explicit operator NextOfKinViewModel(NextOfKin source)
        {
            var destination = new NextOfKinViewModel();
            destination.Name = source.Name;
            destination.Relationhsip = source.Relationhsip;
            destination.PhoneNumber = source.PhoneNumber;
            destination.Address = source.Address;
            return destination;
        }


        public static explicit operator NextOfKin(NextOfKinViewModel source)
        {
            var destination = new NextOfKin();
            destination.Name = source.Name;
            destination.Relationhsip = source.Relationhsip;
            destination.PhoneNumber = source.PhoneNumber;
            destination.Address = source.Address;
            return destination;




        }





    }
}
