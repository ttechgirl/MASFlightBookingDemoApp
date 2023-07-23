using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Org.BouncyCastle.Utilities.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MASFlightBooking.Domain.Models.UserIdentityModel;

namespace MASFlightBooking.Domain.Models.Map
{
    public class AppUserMap : IEntityTypeConfiguration<AppUsers>
    {
        public static PasswordHasher<AppUsers> Hasher { get; set; } = new PasswordHasher<AppUsers>();

        public void Configure(EntityTypeBuilder<AppUsers> builder)
        {
            builder.ToTable(nameof(AppUsers));
            SetUpData(builder);
        }
      
        private void SetUpData(EntityTypeBuilder<AppUsers>builder)
        {
            var users = new AppUsers[]
            {
                new AppUsers
                {
                   //Id = Guid.NewGuid(),
                   //FirstName = "Akeem",
                   //LastName = "Mustapha",
                   //PhoneNumber = "08055423378",
                   //Email = "akeem234@gmail.com",
                   //PasswordHash = Hasher.HashPassword(null, "AHakeem1%")

                },
            };
        }
    
    
    
    }
}
