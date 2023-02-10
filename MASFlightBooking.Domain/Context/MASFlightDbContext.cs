using MASFlightBooking.Domain.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MASFlightBooking.Domain.Models.UserIdentityModel;

namespace MASFlightBooking.Domain.Context
{
    public class MASFlightDbContext : IdentityDbContext<AppUsers,AppRoles,Guid,AppUserClaim,AppUserRoles, AppUserLogin,AppRoleClaim, AppUserToken>
    {
        public MASFlightDbContext(DbContextOptions options) : base(options)
        {

        }
       
        public  DbSet<MASFlightBookingModel> MASFlights { get; set; }
        

    }
}
