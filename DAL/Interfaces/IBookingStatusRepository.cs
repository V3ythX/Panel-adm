using DAL.Entities;
using DTO.BookingStatus;

namespace DAL.Interfaces;

public interface IBookingStatusRepository:IRepository<BookingStatusDto, CreateBookingStatusDto, UpdateBookingStatusDto>
{
    
}