using MASFlightBooking.Domain.Enums;
using MASFlightBooking.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MASFlightBooking.Domain.ViewModels
{
    public class PassangerInfoViewModel
    {
        public string? Name { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public NextOfKinViewModel? NextOfKin { get; set; }
        public Guid NextOfKinId { get; set; }
        public TravelerAge MaturityLevel { get; set; }





        public static explicit operator PassangerInfoViewModel(PassangerInfoModel source)
        {
            var destination = new PassangerInfoViewModel();
            destination.Name = source.Name;
            destination.PhoneNumber = source.PhoneNumber;
            destination.Email = source.Email;
            destination.Address = source.Address;
            destination.NextOfKin = (NextOfKinViewModel?)source.NextOfKin;
            destination.NextOfKinId = source.NextOfKinId;
            return destination;
        }

       
        public static explicit operator PassangerInfoModel(PassangerInfoViewModel source)
        {
            var destination = new PassangerInfoModel();
            destination.Name = source.Name;
            destination.PhoneNumber = source.PhoneNumber;
            destination.Email = source.Email;
            destination.Address = source.Address;
            destination.NextOfKin = (NextOfKin?)source.NextOfKin;
            destination.NextOfKinId = source.NextOfKinId;
            return destination;



        }
    }
}
