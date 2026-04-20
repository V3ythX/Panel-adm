using BLL.Interfaces;
using DAL.Interfaces;
using DTO.Booking;

namespace BLL.Services;

public class BookingService(IBookingRepository bookingRepository) : IBookingService
{
    public async Task<List<BookingDto>> GetBookings() => await bookingRepository.GetAll();
    public async Task<BookingDto> GetBooking(Guid Id) => await bookingRepository.GetById(Id);
    public async Task<BookingDto> CreateBooking(CreateBookingDto booking) => await bookingRepository.Create(booking);
    public async Task<BookingDto> UpdateBooking(UpdateBookingDto booking) => await bookingRepository.Update(booking);
    public async Task DeleteBooking(Guid Id) => await bookingRepository.Delete(Id);
}