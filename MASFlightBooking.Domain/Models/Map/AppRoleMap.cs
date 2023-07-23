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
   
        public static void SetUpData(EntityTypeBuilder<AppRoles> builder)
        {
            var appRoles = new AppRoles[]
            {
                new AppRoles
                {

                    //Id = Guid.Parse("69D545C8-B65E-4FFF-82AC-BCE73AC289A3"),
                    //Name = "User",
                    //NormalizedName = "User",
                    //ConcurrencyStamp = "1"

                },
                
            };

        }
    }
}






