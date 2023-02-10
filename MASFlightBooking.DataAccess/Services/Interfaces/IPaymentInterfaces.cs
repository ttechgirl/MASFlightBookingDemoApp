 using MASFlightBooking.Domain.Models.Payments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MASFlightBooking.DataAccess.Services.Interfaces
{
    public interface IPaymentInterfaces
    {
        Task<PaymentResponseModel> InitiatePayment(PaymentRequestModel model);

        Task<PaymentVerificationResponseModel> VerifyPayment(string transactionId);
    }
}
