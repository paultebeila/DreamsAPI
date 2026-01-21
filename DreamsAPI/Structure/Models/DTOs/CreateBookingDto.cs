using System.ComponentModel.DataAnnotations;

namespace DreamsAPI.Structure.Models.DTOs
{
    public class CreateBookingDto
    {
        [Required, MinLength(3)]
        public string GuestName { get; set; } = string.Empty;

        [Required, EmailAddress]
        public string Email { get; set; } = string.Empty;

        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }

        [Required]
        public string RoomType { get; set; } = string.Empty;

        public BookingStatus Status { get; set; }
        public int NumberOfGuests { get; set; }
    }
}
