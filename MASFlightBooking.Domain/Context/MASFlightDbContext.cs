using MASFlightBooking.Domain.Extensions;
using MASFlightBooking.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
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
        public MASFlightDbContext(DbContextOptions<MASFlightDbContext> options) : base(options)
        {

        }
       

        protected override void OnModelCreating(ModelBuilder builder)
        {
           base.OnModelCreating(builder);
            builder.UseIdentityColumns();

        }

        public DbSet<MASFlightBookingModel> MASFlights { get; set; }

       
    }
}
