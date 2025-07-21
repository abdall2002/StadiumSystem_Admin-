using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StatiumSystem.Models;

namespace StadiumSystem.Model
{
    public class ReserveConfiguration : IEntityTypeConfiguration<Reservation>
    {
        public void Configure(EntityTypeBuilder<Reservation> builder)
        {
            builder.ToTable("Reservations");

            builder.HasKey(r => r.Id);

            builder.Property(r => r.UserName)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(r => r.Status)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(r => r.ReservationDate)
                   .IsRequired();

            builder.Property(r => r.StartTime)
                   .IsRequired();

            builder.Property(r => r.EndTime)
                   .IsRequired();

            builder.HasOne(r => r.Stadium)
                   .WithMany(s => s.Reservations)
                   .HasForeignKey(r => r.StadiumId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
