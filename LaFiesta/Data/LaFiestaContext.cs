using LaFiesta.Areas.Identity.Data;
using LaFiesta.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LaFiesta.Data
{
    public class LaFiestaContext : IdentityDbContext<CustomUser>
    {
        public LaFiestaContext(DbContextOptions<LaFiestaContext> option) : base(option)
        {
        }

        public DbSet<Artiest> Artiesten { get; set; }
        public DbSet<Festival> Festivals { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<FestivalArtiest> FestivalArtiests { get; set; }
        public DbSet<Locatie> Locaties { get; set; }
        public DbSet<TicketFestival> TicketFestivals { get; set; }
        public DbSet<CustomUser> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasDefaultSchema("LaFiestaDB");
            modelBuilder.Entity<Artiest>().ToTable("Artiest");
            modelBuilder.Entity<Festival>().ToTable("Festival");
            modelBuilder.Entity<Ticket>().ToTable("Ticket").Property(p => p.Prijs).HasColumnType("decimal(18,2)");
            modelBuilder.Entity<FestivalArtiest>().ToTable("FestivalArtiest");
            modelBuilder.Entity<Locatie>().ToTable("Locatie");
            modelBuilder.Entity<TicketFestival>().ToTable("TicketFestival");
        }
    }
}
