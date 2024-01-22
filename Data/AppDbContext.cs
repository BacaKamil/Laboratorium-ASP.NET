using Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public DbSet<ContactEntity> Contacts { get; set; }
        public DbSet<OrganizationEntity> Organizations { get; set; }
        public DbSet<HotelEntity> Hotels { get; set; }
        public DbSet<TownEntity> Towns { get; set; }
        public DbSet<ReservationEntity> Reservations { get; set; }

        private string DbPath { get; set; }

        public AppDbContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "ASP.db");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options) =>
            options.UseSqlite($"Data Source={DbPath}");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            string ADMIN_ID = Guid.NewGuid().ToString();
            string EWA_ID = Guid.NewGuid().ToString();

            string ADMIN_ROLE_ID = Guid.NewGuid().ToString();
            string USER_ROLE_ID = Guid.NewGuid().ToString();


            var user = new IdentityUser
            {
                Id = ADMIN_ID,
                Email = "adam@wsei.edu.pl",
                EmailConfirmed = true,
                UserName = "adam",
                NormalizedEmail = "ADAM@WSEI.EDU.PL",
                NormalizedUserName = "ADAM"

            };
            PasswordHasher<IdentityUser> ph = new PasswordHasher<IdentityUser>();
            user.PasswordHash = ph.HashPassword(user, "Admin123@");

            var ewa = new IdentityUser
            {
                Id = EWA_ID,
                Email = "ewa@wsei.edu.pl",
                EmailConfirmed = true,
                UserName = "ewa",
                NormalizedEmail = "EWA@WSEI.EDU.PL",
                NormalizedUserName = "EWA"

            };
            PasswordHasher<IdentityUser> pr = new PasswordHasher<IdentityUser>();
            ewa.PasswordHash = pr.HashPassword(ewa, "Ewa123@");



            var adminRole = new IdentityRole
            {
                Name = "ADMIN",
                NormalizedName = "ADMIN",
                Id = ADMIN_ROLE_ID,
                ConcurrencyStamp = ADMIN_ROLE_ID
            };



            var userRole = new IdentityRole
            {
                Name = "USER",
                NormalizedName = "USER",
                Id = USER_ROLE_ID,
                ConcurrencyStamp = USER_ROLE_ID
            };



            modelBuilder.Entity<IdentityUser>().HasData(user, ewa);
            modelBuilder.Entity<IdentityRole>().HasData(adminRole, userRole);

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string> { RoleId = ADMIN_ROLE_ID, UserId = ADMIN_ID },
                new IdentityUserRole<string> { RoleId = USER_ROLE_ID, UserId = EWA_ID }
            );






            modelBuilder.Entity<HotelEntity>().HasData(
            new HotelEntity()
            {
                Id = 1,
                Name = "Hilton Garden Inn",
                Address = "Marii Konopnickiej 33, 30-302 Kraków",
                Town = 1,
            },
            new HotelEntity()
            {
                Id = 2,
                Name = "Sheraton Grand",
                Address = "Bolesława Prusa 2, 00-493 Warszawa",
                Town= 2
            },
            new HotelEntity()
            {
                Id = 3,
                Name = "Ibis Styles",
                Address = "Żywiecka 93, 43-300 Bielsko-Biała",
                Town= 4,
            },
            new HotelEntity()
            {
                Id = 4,
                Name = "Qubus",
                Address = "Świętej Marii Magdaleny 2, 50-103 Wrocław",
                Town= 3,
            }
            );


            modelBuilder.Entity<ReservationEntity>()
                .HasOne(r => r.Hotel)
                .WithMany(h => h.Reservations)
                .HasForeignKey(r => r.HotelId);






            modelBuilder.Entity<OrganizationEntity>().HasData(
            new OrganizationEntity()
            {
                Id = 1,
                Name = "WSEI",
                Descryption = "Uczelnia",
            },
            new OrganizationEntity()
            {
                Id = 2,
                Name = "UJ",
                Descryption = "Uczelnia",
            },
            new OrganizationEntity()
            {
                Id = 3,
                Name = "AGH",
                Descryption = "Uczelnia",
            },
            new OrganizationEntity()
            {
                Id = 4,
                Name = "NOKIA",
                Descryption = "Firma",
            }
            );

            modelBuilder.Entity<ContactEntity>()
                .HasOne(c => c.Organization)
                .WithMany(o => o.Contacts)
                .HasForeignKey(c => c.OrganizationId);




            modelBuilder.Entity<TownEntity>().HasData(
            new TownEntity()
            {
                Id = 1,
                Town = "Kraków",
            },
            new TownEntity()
            {
                Id = 2,
                Town = "Warszawa",
            },
            new TownEntity()
            {
                Id = 3,
                Town = "Wrocław",
            },
            new TownEntity()
            {
                Id = 4,
                Town = "Bielsko-Biała",
            }
            );

            //modelBuilder.Entity<HotelEntity>()
            //    .HasOne(c => c.Town)
            //    .WithOne(o => o.Hotels.Town)
            //    .HasForeignKey(c => c.TownId);

        }
    }
}