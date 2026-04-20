using BLL.Interfaces;
using DAL.Interfaces;
using DTO.BookingStatus;

namespace BLL.Services;

public class BookingStatusService(IBookingStatusRepository bookingStatusRepository):IBookingStatusService
{
    public async Task<List<BookingStatusDto>> GetBookingStatuses()=> await bookingStatusRepository.GetAll();
    public async Task<BookingStatusDto> GetBookingStatus(Guid Id) => await bookingStatusRepository.GetById(Id);
    public async Task<BookingStatusDto> CreateBookingStatus(CreateBookingStatusDto bookingStatus) => await bookingStatusRepository.Create(bookingStatus);
    public async Task<BookingStatusDto> UpdateBookingStatus(UpdateBookingStatusDto bookingStatus) => await bookingStatusRepository.Update(bookingStatus);
    public async Task DeleteBookingStatus(Guid Id) => await bookingStatusRepository.Delete(Id);
    
    
}