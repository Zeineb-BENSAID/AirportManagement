﻿using AM.ApplicationCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Infrastructure.Configurations
{
    public class FlightConfiguration : IEntityTypeConfiguration<Flight>
    {
        public void Configure(EntityTypeBuilder<Flight> builder)
        {
            //Configurer la relation many-to-many entre la classe Flight et la classe Passenger

            builder.HasMany(f => f.Passengers).WithMany(p => p.Flights)
                .UsingEntity(e => e.ToTable("Reservations"));//renommer la table d'association

            //Configurer la relation one-to-many entre la classe Flight et la classe Plane

            builder.HasOne(f=>f.Plane).WithMany(p=>p.Flights)
                .HasForeignKey(f=>f.PlaneFK).OnDelete(DeleteBehavior.Cascade);

        }
    }
}
