using DTO.Booking;

namespace BLL.Interfaces;

public interface IBookingService
{
    Task<List<BookingDto>> GetBookings();
    Task<BookingDto> GetBooking(Guid Id);
    Task<BookingDto> CreateBooking(CreateBookingDto booking);
    Task<BookingDto> UpdateBooking(UpdateBookingDto booking);
    Task DeleteBooking(Guid Id);
}