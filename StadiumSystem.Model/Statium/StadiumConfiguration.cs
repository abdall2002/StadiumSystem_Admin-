using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StatiumSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StadiumSystem.Model.Statium
{
    public class StadiumConfiguration : IEntityTypeConfiguration<Stadium>
    {
        public void Configure(EntityTypeBuilder<Stadium> builder)
        {
            builder.ToTable("Stadiums");

            builder.HasKey(s => s.Id);

            builder.Property(s => s.Name)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(s => s.ImageUrl)
                   .HasMaxLength(2048); // optional: set reasonable max length for URL columns

            builder.HasMany(s => s.Reservations)
                   .WithOne(r => r.Stadium)
                   .HasForeignKey(r => r.StadiumId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
