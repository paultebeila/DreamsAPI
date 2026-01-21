using DreamsAPI.Structure.Models;

namespace DreamsAPI.Structure.Interfaces
{
    public interface IBookingServices
    {
        Task<IEnumerable<Booking>> GetAllAsync(string? roomType, BookingStatus? status);
        Task<Booking?> GetByIdAsync(int id);
        Task<(bool IsValid, string? Message)> ValidateAsync(Booking booking);
        Task<Booking> CreateAsync(Booking booking);
        Task UpdateAsync(Booking booking);
        Task DeleteAsync(int id);
    }
}
