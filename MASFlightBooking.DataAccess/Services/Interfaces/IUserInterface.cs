using MASFlightBooking.Domain.Models;
using MASFlightBooking.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MASFlightBooking.DataAccess.Services.Interfaces
{
    public interface IUserInterface
    {
        Task<ResponseViewModel> RegisterUser(RegisterViewModel registerModel);
        Task<ResponseViewModel> LoginUser(LoginViewModel loginModel);
    }
}