using DTO.Booking;

namespace DAL.Interfaces;

public interface IBookingRepository : IRepository<BookingDto, CreateBookingDto, UpdateBookingDto>
{
    
}