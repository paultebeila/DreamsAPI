using DreamsAPI.Structure.Interfaces;
using DreamsAPI.Structure.Models;
using DreamsAPI.Structure.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace DreamsAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookingsController : ControllerBase
    {
        private readonly IBookingServices _service;

        public BookingsController(IBookingServices service)
        {
            _service = service;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAll([FromQuery] string? roomType, [FromQuery] BookingStatus? status)
        {
            var bookings = await _service.GetAllAsync(roomType, status);
            return Ok(bookings);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var booking = await _service.GetByIdAsync(id);
            if (booking == null)
            {
                return NotFound();
            }
            return Ok(booking);
        }

        [HttpPost("book")]
        public async Task<IActionResult> Create(CreateBookingDto dto)
        {
            var booking = new Booking
            {
                GuestName = dto.GuestName,
                Email = dto.Email,
                CheckInDate = dto.CheckInDate,
                CheckOutDate = dto.CheckOutDate,
                RoomType = dto.RoomType,
                Status = dto.Status,
                NumberOfGuests = dto.NumberOfGuests
            };

            var (isValid, message) = await _service.ValidateAsync(booking);

            if (!isValid)
            {
                return BadRequest(message);
            }

            var created = await _service.CreateAsync(booking);

            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update(int id, UpdateBookingDto dto)
        {
            var booking = await _service.GetByIdAsync(id);
            if (booking == null)
            {
                return NotFound();
            }

            booking.GuestName = dto.GuestName;
            booking.Email = dto.Email;
            booking.CheckInDate = dto.CheckInDate;
            booking.CheckOutDate = dto.CheckOutDate;
            booking.RoomType = dto.RoomType;
            booking.Status = dto.Status;
            booking.NumberOfGuests = dto.NumberOfGuests;

            var (isValid, message) = await _service.ValidateAsync(booking);

            if (!isValid)
            {
                return BadRequest(message);
            }

            await _service.UpdateAsync(booking);
            return NoContent();
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}
