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
    public class Context : DbContext
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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


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

        }






    }
}
