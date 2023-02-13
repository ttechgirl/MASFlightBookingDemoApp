using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MASFlightBooking.Domain.Models.UserIdentityModel;

namespace MASFlightBooking.Domain.Models.Map
{
    public class AppRoleMap : IEntityTypeConfiguration<AppRoles>
    {
        public void Configure(EntityTypeBuilder<AppRoles> builder)
        {
            builder.ToTable(nameof(AppRoles));
            SetUpData(builder);

        }
   
        private void SetUpData(EntityTypeBuilder<AppRoles> builder)
        {
            var appRoles = new AppRoles[]
            {
                new AppRoles
                {
                    Id = Guid.Parse("42a81885-30d8-4769-8c31-eb73bfe098b1"),
                    Name = "Admin User",
                    NormalizedName = "Admin User",
                    IsInBuilt = true,

                },
                
            };

        }
    }
}




//seed data to be added for approleclaims 


