using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DreamsAPI.Structure.Models
{
    public class Booking
    {
        public int Id { get; set; }

        [Required, MinLength(3)]
        public string GuestName { get; set; } = string.Empty;

        [EmailAddress]
        public string? Email { get; set; }

        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }

        [Required]
        public string RoomType { get; set; } = string.Empty;

        public BookingStatus Status { get; set; }

        public int NumberOfGuests { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [NotMapped]
        public int TotalNights => (CheckOutDate - CheckInDate).Days;
    }
}
