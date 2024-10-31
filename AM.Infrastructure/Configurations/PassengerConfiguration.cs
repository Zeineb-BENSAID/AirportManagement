using AM.ApplicationCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Infrastructure.Configurations
{
    public class PassengerConfiguration : IEntityTypeConfiguration<Passenger>
    {
        public void Configure(EntityTypeBuilder<Passenger> builder)
        {
            builder.OwnsOne(p => p.FullName, full => 
            { 
               full.Property(f=>f.FirstName).HasMaxLength(30).HasColumnName("PassFirstName");
               full.Property(f => f.LastName).IsRequired().HasColumnName("PassLastName");
            });

            // TPH: Table per hierarchy

            //builder.HasDiscriminator<int>("IsTraveller")
            //    .HasValue<Traveller>(1)
            //    .HasValue<Staff>(0)
            //    .HasValue<Passenger>(2);
        }
    }
}
