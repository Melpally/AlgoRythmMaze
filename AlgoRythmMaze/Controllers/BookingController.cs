using AlgoRythmMaze.Application.Dtos;
using Microsoft.AspNetCore.Mvc;
using TopiTopi.Application.Interfaces;

namespace TopiTopi.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;

        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateBooking([FromForm] BookingDto bookingDto)
        {
            await _bookingService.CreateBookingAsync(bookingDto);
            return Ok("Booking created successfully and synced to Google Calendar.");
        }
    }
}
