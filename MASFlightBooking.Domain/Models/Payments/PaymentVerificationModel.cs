using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MASFlightBooking.Domain.Models.Payments
{
    public class PaymentVerificationResponseModel
    {
            public string? message { get; set; }
            public string? status { get; set; }
            public FlutterWaveData? data { get; set; }

    }
    public class FlutterWaveData
    {
            public string? id { get; set; }
            public string? account_id { get; set; }
            public string? tx_id { get; set; }
            public string? flw_ref { get; set; }
            public string? wallet_id { get; set; }
            public decimal amount_refunded { get; set; }
            public string? status { get; set; }
            public string? destination { get; set; }

    }

}
