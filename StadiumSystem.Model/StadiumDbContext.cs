using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StadiumSystem.Model;
using StadiumSystem.Model.Statium;

namespace StatiumSystem.Models
{
    public class StadiumDbContext : IdentityDbContext<IdentityUser>
    {
        public StadiumDbContext(DbContextOptions<StadiumDbContext> options) : base(options)
        {

        }

        public DbSet<Stadium> Stadiums { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<User> Users {  get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new StadiumConfiguration().Configure(modelBuilder.Entity<Stadium>());
            new ReserveConfiguration().Configure(modelBuilder.Entity<Reservation>());

            base.OnModelCreating(modelBuilder);
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

    }
}
