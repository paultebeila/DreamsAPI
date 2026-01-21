using DreamsAPI.Structure.Models;
using Microsoft.EntityFrameworkCore;

namespace DreamsAPI.Structure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<Booking> Bookings => Set<Booking>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Booking>().HasData(
                new Booking
                {
                    Id = 1,
                    GuestName = "John Smith",
                    Email = "john.smith@example.com",
                    CheckInDate = DateTime.Today.AddDays(10),
                    CheckOutDate = DateTime.Today.AddDays(13),
                    RoomType = "Deluxe",
                    Status = BookingStatus.Confirmed,
                    NumberOfGuests = 2,
                    CreatedAt = DateTime.UtcNow
                },
                new Booking
                {
                    Id = 2,
                    GuestName = "Mary Johnson",
                    Email = "mary@example.com",
                    CheckInDate = DateTime.Today.AddDays(15),
                    CheckOutDate = DateTime.Today.AddDays(18),
                    RoomType = "Suite",
                    Status = BookingStatus.Pending,
                    NumberOfGuests = 3,
                    CreatedAt = DateTime.UtcNow
                }
            );
        }
    }
}
