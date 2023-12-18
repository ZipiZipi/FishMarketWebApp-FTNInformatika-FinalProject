using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ZavrsniTest.Models
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Ribarnica> Ribarnice { get; set; }
        public DbSet<Riba> Ribe { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ribarnica>().HasData(
                new Ribarnica() { Id = 1, Naziv = "Dunav doo", GodinaOtvaranja = 2015 },
                new Ribarnica() { Id = 2, Naziv = "Tisa str", GodinaOtvaranja = 2012 },
                new Ribarnica() { Id = 3, Naziv = "Sveza riba", GodinaOtvaranja = 2015 }
            );

            modelBuilder.Entity<Riba>().HasData(
                new Riba()
                {
                    Id = 1,
                    Sorta = "Smudj",
                    Mesto = "Ribnjak Bager",
                    Cena = 1100,
                    Kolicina = 20,
                    RibarnicaId = 3
                },
                new Riba()
                {
                    Id = 2,
                    Sorta = "Saran",
                    Mesto = "Dunav",
                    Cena = 860,
                    Kolicina = 30,
                    RibarnicaId = 1
                },
                new Riba()
                {
                    Id = 3,
                    Sorta = "Som",
                    Mesto = "Tisa",
                    Cena = 1300,
                    Kolicina = 10,
                    RibarnicaId = 2
                },
                new Riba()
                {
                    Id = 4,
                    Sorta = "Saran",
                    Mesto = "Ribnjak Ecka",
                    Cena = 780,
                    Kolicina = 12,
                    RibarnicaId = 3
                },
                new Riba()
                {
                    Id = 5,
                    Sorta = "Smudj",
                    Mesto = "Dunav",
                    Cena = 950,
                    Kolicina = 15,
                    RibarnicaId = 1
                }
            );

            base.OnModelCreating(modelBuilder);
        }
    }
}
