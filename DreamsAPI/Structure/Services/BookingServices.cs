using DreamsAPI.Structure.Data;
using DreamsAPI.Structure.Interfaces;
using DreamsAPI.Structure.Models;
using Microsoft.EntityFrameworkCore;

namespace DreamsAPI.Structure.Services
{
    public class BookingService : IBookingServices
    {
        private readonly AppDbContext _context;
        private readonly ILogger<BookingService> _logger;

        public BookingService(AppDbContext context, ILogger<BookingService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<IEnumerable<Booking>> GetAllAsync(string? roomType, BookingStatus? status)
        {
            var query = _context.Bookings.AsQueryable();

            if (!string.IsNullOrWhiteSpace(roomType))
            {
                query = query.Where(b => b.RoomType == roomType);
            }

            if (status.HasValue)
            {
                query = query.Where(b => b.Status == status);
            }

            return await query
                .OrderByDescending(b => b.CreatedAt)
                .ToListAsync();
        }

        public Task<Booking?> GetByIdAsync(int id)
            => _context.Bookings.FindAsync(id).AsTask();

        public async Task<(bool IsValid, string? Message)> ValidateAsync(Booking booking)
        {
            if (booking.CheckInDate <= DateTime.Today)
            {
                return (false, "Check-in date must be in the future.");
            }

            if (booking.CheckOutDate <= booking.CheckInDate)
            {
                return (false, "Check-out date must be after check-in.");
            }

            if (booking.TotalNights > 14)
            {
                return (true, "Warning: Maximum recommended stay is 14 nights.");
            }

            return (true, null);
        }

        public async Task<Booking> CreateAsync(Booking booking)
        {
            _context.Bookings.Add(booking);
            await _context.SaveChangesAsync();
            return booking;
        }

        public async Task UpdateAsync(Booking booking)
        {
            _context.Bookings.Update(booking);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var booking = await _context.Bookings.FindAsync(id);
            if (booking == null)
            {
                return;
            }

            _context.Bookings.Remove(booking);
            await _context.SaveChangesAsync();
        }
    }
}
