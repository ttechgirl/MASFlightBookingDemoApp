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
    public class AppUserMap : IEntityTypeConfiguration<AppUsers>
    {
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
                    Id = Guid.Parse("2ec30fa6-55f0-401e-ad9a-78e16992dc29"),
                    UserName = "Shazy",
                    NormalizedUserName = "Shazy",
                    NormalizedEmail = "ayisatmustapha@icloud.com",
                    ConcurrencyStamp =Guid.NewGuid().ToString(),

                },
            };
        }
    
    
    
    }
}
