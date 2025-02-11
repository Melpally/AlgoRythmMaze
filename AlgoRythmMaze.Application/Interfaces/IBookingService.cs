using AlgoRythmMaze.Application.Dtos;

namespace TopiTopi.Application.Interfaces
{
    public interface IBookingService
    {
        Task CreateBookingAsync(BookingDto bookingDto);
    }
}
