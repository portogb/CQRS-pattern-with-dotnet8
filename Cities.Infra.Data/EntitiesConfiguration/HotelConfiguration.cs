using Cities.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cities.Infra.Data.EntitiesConfiguration
{
    public class HotelConfiguration : IEntityTypeConfiguration<Hotel>
    {
        public void Configure(EntityTypeBuilder<Hotel> builder)
        {
            builder.ToTable("Hotels");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .IsRequired();

            builder.Property(x => x.Daily)
                .IsRequired();
            
            builder.HasOne(hotel => hotel.City)
                .WithMany(y => y.Hotels)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
