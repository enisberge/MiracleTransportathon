using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MiracleTransportathon.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiracleTransportathon.DataAccesLayer.Concrete
{
    //veritabanına bağlandığımız kısım
    public class Context : IdentityDbContext<User,Role,int>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer("server=(localdb)\\MSSQLLocalDB;database=MiracleTransportathonDb; integrated security=true");
            optionsBuilder.UseSqlServer("server=(LocalDb)\\MSSQLLocalDB;database=MiracleTransportathonDb; integrated security=true");

        }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Offer> Offers { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<Locality> Localities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Company>()
            .Property(c => c.WebSite)
            .IsRequired(false);

            modelBuilder.Entity<Company>()
           .Property(c => c.Type)
           .IsRequired(false);
            modelBuilder.Entity<Company>()
          .Property(c => c.Address)
          .IsRequired(false);

            modelBuilder.Entity<User>()
                .HasMany(u => u.SentMessages)
                .WithOne(m => m.Sender)
                .HasForeignKey(m => m.SenderId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<User>()
                .HasMany(u => u.ReceivedMessages)
                .WithOne(m => m.Receiver)
                .HasForeignKey(m => m.ReceiverId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<User>()
                .HasMany(u => u.Reviews)
                .WithOne(r => r.User)
                .HasForeignKey(r => r.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Request>()
                .HasMany(r => r.Offers)
                .WithOne(o => o.Request)
                .HasForeignKey(o => o.RequestId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Vehicle>()
                .HasMany(v => v.Offers)
                .WithOne(o => o.Vehicle)
                .HasForeignKey(o => o.VehicleId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Request>()
            .HasOne(r => r.Reservation)
            .WithOne(p => p.Request)
            .HasForeignKey<Reservation>(p => p.RequestId)
            .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<User>()
             .HasMany(u => u.Reservations)
             .WithOne(r => r.User)
             .HasForeignKey(r => r.UserId)
             .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Request>()//her şehir birden fazla talepte olabilir
                .HasOne(r => r.OriginCity)
                .WithMany(c => c.OriginRequests)
                .HasForeignKey(r => r.OriginCityId)
             .OnDelete(DeleteBehavior.NoAction);


            modelBuilder.Entity<Request>()
              .HasOne(r => r.DestinationCity)
              .WithMany(c => c.DestinationRequests)
              .HasForeignKey(r => r.DestinationCityId)
               .OnDelete(DeleteBehavior.NoAction);


            modelBuilder.Entity<Request>()
              .HasOne(r => r.OriginDistrict)
              .WithMany(d => d.OriginRequests)
              .HasForeignKey(r => r.OriginDistrictId)
               .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Request>()
              .HasOne(r => r.DestinationDistrict)
              .WithMany(d => d.DestinationRequests)
              .HasForeignKey(r => r.DestinationDistrictId)
               .OnDelete(DeleteBehavior.NoAction);


            modelBuilder.Entity<Request>()
            .HasOne(r => r.OriginLocality)
            .WithMany(l => l.OriginRequests)
            .HasForeignKey(r => r.OriginLocalityId)
             .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Request>()
            .HasOne(r => r.DestinationLocality)
            .WithMany(l => l.DestinationRequests)
            .HasForeignKey(r => r.DestinationLocalityId)
             .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Company>()
     .HasOne(c => c.User)
     .WithOne(u => u.Company)
     .HasForeignKey<Company>(c => c.UserId)
     .OnDelete(DeleteBehavior.NoAction);


            //     modelBuilder.Entity<City>()
            //.HasMany(c => c.Districts)
            //.WithOne(d => d.City)
            //.HasForeignKey(d => d.CityId);

            //     modelBuilder.Entity<City>()
            //         .Property(c => c.PlateNumber)
            //         .IsRequired();
            base.OnModelCreating(modelBuilder);
        }




       

    }
}
