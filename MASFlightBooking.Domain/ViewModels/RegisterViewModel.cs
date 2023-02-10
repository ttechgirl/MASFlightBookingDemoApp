using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MASFlightBooking.Domain.ViewModels 
{
    public class RegisterViewModel
    {

        //data annotation(required)
        [Required, MaxLength(50)]
        public string? UserName { get; set; }

        [Required(ErrorMessage = "Email is  required")]
        [EmailAddress]
        public string? Email { get; set; }

        [Required, DataType(DataType.Password)]
        [StringLength(15, ErrorMessage = "password must be at least 8 characters")]
        public string? Password { get; set; }

        [DataType(DataType.Password), Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "Password mismatched, try again")]
        public string? ConfirmPassword { get; set; }

        public bool RememberMe { get; set; } = true;

    }
}
