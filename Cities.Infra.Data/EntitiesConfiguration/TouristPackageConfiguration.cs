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
    public class TouristPackageConfiguration : IEntityTypeConfiguration<TouristPackage>
    {
        public void Configure(EntityTypeBuilder<TouristPackage> builder)
        {
            builder.ToTable("TouristPackages");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.TravelDay)
                .IsRequired();

            builder.Property(x => x.TotalDays)
                .IsRequired();

            builder.HasOne(x => x.City)
                .WithMany(y => y.TouristPackages)
                .HasForeignKey(x => x.CityId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Hotel)
                .WithMany()
                .HasForeignKey(x => x.HotelId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Restaurant)
                .WithMany()
                .HasForeignKey(x => x.RestaurantId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
