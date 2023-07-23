using MASFlightBooking.Domain.ViewModel.AuthViewModel;
using MASFlightBooking.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MASFlightBooking.DataAccess.Services.Interfaces
{
    public interface IUserAuthRepository
    {
        Task<ResponseViewModel> SignUp(SignUpViewModel model);
        Task<ResponseViewModel> Login(LoginViewModel model);
        Task<ResponseViewModel> ForgetPassword(ForgetPasswordViewModel model);
        Task<ResponseViewModel> ResetPassword(ResetPasswordViewModel model);
        Task<ResponseViewModel> ChangePassword(ChangePasswordViewModel model);
        Task<ResponseViewModel> DeleteProfile(Guid Id);
    }
}
