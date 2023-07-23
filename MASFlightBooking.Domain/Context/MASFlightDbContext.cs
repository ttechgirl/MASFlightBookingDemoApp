using MASFlightBooking.Domain.Extensions;
using MASFlightBooking.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
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
        { }

        public MASFlightDbContext() { }

        public DbSet<MASFlightBookingModel> MASFlights { get; set; }
        public DbSet<AirlineModel> Airlines { get; set; }
        public DbSet<FlightCategoryModel> FlightCategories { get; set; }
        public DbSet<PassangerInfoModel> PassangerInfos { get; set; }
        public DbSet<AppUsers> AppUsers { get; set; }
        public DbSet<AppRoles> AppRoles { get; set; }



        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
           // builder.UseIdentityColumns();
            builder.Seed();

        }

        public class MASFlightDbContextFactory : IDesignTimeDbContextFactory<MASFlightDbContext>
        {
            public MASFlightDbContext CreateDbContext(string[] args)
            {
                var optionsBuilder = new DbContextOptionsBuilder<MASFlightDbContext>();
                optionsBuilder.UseSqlServer("Server=SHAZYPC\\SQLEXPRESS;Database=MASFlightBooking.API;MultipleActiveResultSets=True;Trusted_Connection=True; ");
                return new MASFlightDbContext(optionsBuilder.Options);
            }
        }
    }


    //public class DateOnlyConverter : ValueConverter<DateOnly, DateTime>
    //{
    //    /// <summary>
    //    /// Creates a new instance of this converter.
    //    /// </summary>
    //    public DateOnlyConverter() : base(
    //            d => d.ToDateTime(TimeOnly.MinValue),
    //            d => DateOnly.FromDateTime(d))
    //    { }
    //}
}
