using MASFlightBooking.DataAccess.Services.Interfaces;
using MASFlightBooking.Domain.Models;
using MASFlightBooking.Domain.ViewModels;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MASFlightBooking.Domain.Models.UserIdentityModel;

namespace MASFlightBooking.DataAccess.Services.Repositories
{
    public class UserRepository : IUserInterface
    {
        private UserManager<AppUsers> _userManager;
        public UserRepository(UserManager<AppUsers> userManager)
        {
            _userManager = userManager;
        }
        public async Task<ResponseViewModel> RegisterUser(RegisterViewModel registerModel)
        {
            if (registerModel ==null)
            {
                throw new NullReferenceException(""); 

            }
            if (registerModel.Password != registerModel.ConfirmPassword)
            {
               var response = new ResponseViewModel();
                response.Success = false;
                response.Message = "Password mismatched, try again";

            }
               
            var appUser = new AppUsers
            {
                UserName = registerModel.UserName,
                Email = registerModel.Email,

            };

            var result = await _userManager.CreateAsync(appUser, registerModel.Password);
            if (result.Succeeded)
            {
                return new ResponseViewModel
                {
                    Success = true,
                    Message = "User successfully created",

                };
            }
            else
            {
                return new ResponseViewModel
                {
                    Success = false,
                    Message = "Unable to create user",
                    Errors = result.Errors.Select(e => e.Description)
                };
            }
        }

        public async Task<ResponseViewModel> LoginUser(LoginViewModel loginModel)
        {
           
            var result = await _userManager.FindByLoginAsync(loginModel.Email,loginModel.Password);
            
           if (result!=null )
                return new ResponseViewModel 
                { 
                    Success = true, 
                    Message ="Credential validated", 

                };
                return new ResponseViewModel
                {
                   Success = false,
                   Message ="Kindly input correct details or create a profile",
                };


        }

    }
}
