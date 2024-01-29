using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketPurchaseManage.Entity;

namespace TicketPurchaseManage.EntityMaps
{
    public class EFDataContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=MEHRDAD;Initial" +
                " Catalog=TicketPurchaseDb;User Id=sa;Password=Mehrdad;" +
                "Trusted_Connection=True;TrustServerCertificate=True;");

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(EFDataContext).Assembly);
            //modelBuilder.Entity<Trip>().HasDiscriminator<int>("Trip discrimation").HasValue<NormalBusTrip>(1).HasValue<VipBusTrip>(2);
            modelBuilder.Entity<Trip>().ToTable("Trips").HasDiscriminator<int>("TripType").HasValue<NormalBusTrip>(1).HasValue<VipBusTrip>(2);
        }
        public DbSet<Bus> Buses {  get; set; }     
        public DbSet<Passenger> Passengers {  get; set; }     
        public DbSet<Seat> Seats {  get; set; }
        public DbSet<Ticket> Tickets {  get; set; }
        public DbSet<Trip> Trips {  get; set; }

        
    }
}
