using DAL.EF;
using DAL.Entities;
using DAL.Interfaces;
using DTO.BookingStatus;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories;

public class BookingStatusRepository(ApplicationContext context):IBookingStatusRepository
{
    public async Task<List<BookingStatusDto>> GetAll()
    {
        List<BookingStatus> bookingStatuses = await context.BookingStatuses.ToListAsync();
        List<BookingStatusDto> bookingStatusList = new List<BookingStatusDto>();
        foreach (var bookingStatus in bookingStatuses)
        {
            BookingStatusDto bookingStatusDto = new()
            {
                Id = bookingStatus.Id,
                Name = bookingStatus.Name,
                CreatedAt = bookingStatus.CreatedAt,
                UpdatedAt = bookingStatus.UpdatedAt,
            };
            bookingStatusList.Add(bookingStatusDto);
        }
        return bookingStatusList;
    }

    public async Task<BookingStatusDto> GetById(Guid id)
    {
        BookingStatus? bookingStatus = await context.BookingStatuses.FindAsync(id);
        return new BookingStatusDto()
        {
            Id = bookingStatus.Id,
            Name = bookingStatus.Name,
            CreatedAt = bookingStatus.CreatedAt,
            UpdatedAt = bookingStatus.UpdatedAt,
        };
    }

    public async Task<BookingStatusDto> Create(CreateBookingStatusDto bookingStatus)
    {
        BookingStatus createdBookingStatus = new()
        {
            Name = bookingStatus.Name,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow,
        };
        context.BookingStatuses.Add(createdBookingStatus);
        await context.SaveChangesAsync();
        return new BookingStatusDto()
        {
            Id = createdBookingStatus.Id,
            Name = createdBookingStatus.Name,
            CreatedAt = createdBookingStatus.CreatedAt,
            UpdatedAt = createdBookingStatus.UpdatedAt,
        };
    }

    public async Task<BookingStatusDto> Update(UpdateBookingStatusDto bookingStatus)
    {
        BookingStatus? updatedBookingStatus = await context.BookingStatuses.FindAsync(bookingStatus.Id);
        updatedBookingStatus.Name = bookingStatus.Name;
        updatedBookingStatus.UpdatedAt = DateTime.UtcNow;
        
        context.BookingStatuses.Update(updatedBookingStatus);
        await context.SaveChangesAsync();
        return new BookingStatusDto()
        {
            Id = updatedBookingStatus.Id,
            Name = updatedBookingStatus.Name,
            CreatedAt = updatedBookingStatus.CreatedAt,
            UpdatedAt = updatedBookingStatus.UpdatedAt,
        };
    }

    public async Task Delete(Guid id)
    {
        BookingStatus? bookingStatus = await context.BookingStatuses.FindAsync(id);
        context.BookingStatuses.Remove(bookingStatus);
        await context.SaveChangesAsync();
    }
    
}