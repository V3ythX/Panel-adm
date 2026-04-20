using DTO.BookingStatus;

namespace BLL.Interfaces;

public interface IBookingStatusService
{
    Task<List<BookingStatusDto>> GetBookingStatuses();
    Task<BookingStatusDto> GetBookingStatus(Guid id);
    Task<BookingStatusDto>CreateBookingStatus(CreateBookingStatusDto bookingStatus);
    Task<BookingStatusDto> UpdateBookingStatus(UpdateBookingStatusDto bookingStatus);
    Task DeleteBookingStatus(Guid id);
    
}