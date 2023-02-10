using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MASFlightBooking.Domain.Models.Payments
{
    public class PaymentResponseModel
    {
        public string? message { get; set; }
        public string? status { get; set; }
        public FLWData? data { get; set; }

    }
    public class FLWData
    {
        public string? link { get; set; }
    }
}
