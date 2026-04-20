using DAL.EF;
using DAL.Entities;
using DAL.Interfaces;
using DTO.Booking;
using DTO.BookingStatus;
using DTO.Event;
using DTO.Payment;
using DTO.User;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories;

public class BookingRepository(ApplicationContext context) : IBookingRepository
{
    public async Task<List<BookingDto>> GetAll()
    {
        //.Include(...) показывает, какие таблицы имеют связи
        //есть в Booking и которые тебе нвдо вывести на экран.
        List<Booking> bookings = await context.Bookings
            .Include(b => b.User)
            .Include(b => b.Event)
            .Include(b => b.BookingStatus)
            .Include(b => b.Payment)
            .ToListAsync(); 
        List<BookingDto> bookingList = new List<BookingDto>();

        foreach (var booking in bookings)
        {
            ///////////////////////////////////////////////////////
            //Эта конструкция находит сущность, которая
            //привязана к записи booking. Такая нужна
            //для каждого поля, которое ты в .Include(...)
            //выше писал.
            //Эта конструкция подходит, если у тебя поле для одно
            UserForOtherDto? userDto = null;
            if (booking.User != null)
            {
                userDto = new UserForOtherDto()
                {
                    //Сюда вписываются поля из UserForOtherDto
                    Id = booking.User.Id,
                    FirstName = booking.User.FirstName,
                    LastName = booking.User.LastName,
                    Patronymic = booking.User.Patronymic,
                };
            }
            ///////////////////////////////////////////////////////
            
            EventForOtherDto? eventDto = null;
            if (booking.Event != null)
            {
                eventDto = new EventForOtherDto()
                {
                    Id = booking.Event.Id,
                    Title = booking.Event.Title,
                };
            }
            
            BookingStatusDto? bookingStatusDto = null;
            if (booking.BookingStatus != null)
            {
                bookingStatusDto = new BookingStatusDto()
                {
                    Id = booking.BookingStatus.Id,
                    Name = booking.BookingStatus.Name,
                };
            }
            
            PaymentForOtherDto? paymentDto = null;
            if (booking.Payment != null)
            {
                paymentDto = new PaymentForOtherDto()
                {
                    Id = booking.Payment.Id,
                };
            }
            
            //Сюда пишутся поля, которые будут выведены на
            //экран для каждой записи booking 
            BookingDto bookingDto = new()
            {
                Id = booking.Id,
                User = userDto,
                Event = eventDto,
                BookingDate = booking.BookingDate,
                BookingStatus = bookingStatusDto,
                NumberOfSeats = booking.NumberOfSeats,
                Payment = paymentDto,
                CreatedAt = booking.CreatedAt,
                UpdatedAt = booking.UpdatedAt,
            };
            bookingList.Add(bookingDto);
        }
        return bookingList;
    }
    
    public async Task<BookingDto> GetById(Guid id)
    {
        Booking? booking = await context.Bookings.FindAsync(id);
        
        ///////////////////////////////////////////////////////
        //Та же конструкция, что была в прошлой функции
        UserForOtherDto? userDto = null;
        if (booking.User != null)
        {
            userDto = new UserForOtherDto()
            {
                //Сюда вписываются поля из UserForOtherDto
                Id = booking.User.Id,
                FirstName = booking.User.FirstName,
                LastName = booking.User.LastName,
                Patronymic = booking.User.Patronymic,
            };
        }
        ///////////////////////////////////////////////////////
            
        EventForOtherDto? eventDto = null;
        if (booking.Event != null)
        {
            eventDto = new EventForOtherDto()
            {
                Id = booking.Event.Id,
                Title = booking.Event.Title,
            };
        }
            
        BookingStatusDto? bookingStatusDto = null;
        if (booking.BookingStatus != null)
        {
            bookingStatusDto = new BookingStatusDto()
            {
                Id = booking.BookingStatus.Id,
                Name = booking.BookingStatus.Name,
            };
        }
            
        PaymentForOtherDto? paymentDto = null;
        if (booking.Payment != null)
        {
            paymentDto = new PaymentForOtherDto()
            {
                Id = booking.Payment.Id,
            };
        }

        return new BookingDto()
        {
            Id = booking.Id,
            User = userDto,
            Event = eventDto,
            BookingDate = booking.BookingDate,
            BookingStatus = bookingStatusDto,
            NumberOfSeats = booking.NumberOfSeats,
            Payment = paymentDto,
            CreatedAt = booking.CreatedAt,
            UpdatedAt = booking.UpdatedAt,
        };
    }
    
    public async Task<BookingDto> Create(CreateBookingDto booking)
    {
        ///////////////////////////////////////////////////////
        //Конструкция для нахождения подходящих записей
        //в других таблицах по их id.
        //Такая строка пишется для каждого поля, которое
        //является вторичным ключом
        User? user = await context.Users
            .FirstOrDefaultAsync(u => u.Id == booking.UserId);
        ///////////////////////////////////////////////////////
        Event? bookingEvent = await context.Events
            .FirstOrDefaultAsync(e => e.Id == booking.EventId);
        BookingStatus? bookingStatus = await context.BookingStatuses
            .FirstOrDefaultAsync(b => b.Id == booking.BookingStatusId);
        Payment? payment = await context.Payments
            .FirstOrDefaultAsync(p => p.Id == booking.PaymentId);

        Booking createBooking = new()
        {
            User = user,
            Event = bookingEvent,
            BookingDate = DateTime.UtcNow,
            BookingStatus = bookingStatus,
            NumberOfSeats = booking.NumberOfSeats,
            Payment = payment,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow,
        };
        context.Bookings.Add(createBooking);
        await context.SaveChangesAsync();

        ///////////////////////////////////////////////////////
        //Конструкция которая преобразует User в UserForOtherDto.
        //Такая нужна для каждой сущности, описанной выше.
        //Данные указанные внутры потом выведутся на экран, 
        //показывая пользователю результат создания новой
        //записи в таблице Bookings
        UserForOtherDto? userDto = new()
        {
            Id = createBooking.User.Id,
            FirstName = createBooking.User.FirstName,
            LastName = createBooking.User.LastName,
            Patronymic = createBooking.User.Patronymic,
        };
        ///////////////////////////////////////////////////////

        EventForOtherDto? eventDto = new()
        {
            Id = createBooking.Event.Id,
            Title = createBooking.Event.Title,
        };

        BookingStatusDto? bookingStatusDto = new()
        {
            Id = createBooking.BookingStatus.Id,
            Name = createBooking.BookingStatus.Name,
        };

        PaymentForOtherDto? paymentDto = new()
        {
            Id = createBooking.Payment.Id,
        };

        return new BookingDto()
        {
            Id = createBooking.Id,
            User = userDto,
            Event = eventDto,
            BookingStatus = bookingStatusDto,
            NumberOfSeats = booking.NumberOfSeats,
            Payment = paymentDto,
            CreatedAt = createBooking.CreatedAt,
            UpdatedAt = createBooking.UpdatedAt,
        };
    }
    
    public async Task<BookingDto> Update(UpdateBookingDto booking)
    {
        Booking? updatedBooking = await context.Bookings.FindAsync(booking.Id); //Поиск нужной запси по id
        ///////////////////////////////////////////////////////
        //Конструкция, которая была выше
        User? user = await context.Users
            .FirstOrDefaultAsync(b => b.Id == booking.UserId);
        ///////////////////////////////////////////////////////
        Event? bookingEvent = await context.Events
            .FirstOrDefaultAsync(e => e.Id == booking.EventId);
        BookingStatus? bookingStatus = await context.BookingStatuses
            .FirstOrDefaultAsync(b => b.Id == booking.BookingStatusId);
        Payment? payment = await context.Payments
            .FirstOrDefaultAsync(p => p.Id == booking.PaymentId);
        
        //Сюда пишутся все обновляемые поля
        updatedBooking.User = user;
        updatedBooking.Event = bookingEvent;
        updatedBooking.BookingStatus = bookingStatus;
        updatedBooking.NumberOfSeats = booking.NumberOfSeats;
        updatedBooking.Payment = payment;
        updatedBooking.UpdatedAt = DateTime.UtcNow;
        
        context.Bookings.Update(updatedBooking);
        await context.SaveChangesAsync();

        ///////////////////////////////////////////////////////
        //Конструкция, как в прошлой функции, только
        //используется updatedBooking
        UserForOtherDto? userDto = new()
        {
            Id = updatedBooking.User.Id,
            FirstName = updatedBooking.User.FirstName,
            LastName = updatedBooking.User.LastName,
            Patronymic = updatedBooking.User.Patronymic,
        };
        ///////////////////////////////////////////////////////

        EventForOtherDto? eventDto = new()
        {
            Id = updatedBooking.Event.Id,
            Title = updatedBooking.Event.Title,
        };

        BookingStatusDto? bookingStatusDto = new()
        {
            Id = updatedBooking.BookingStatus.Id,
            Name = updatedBooking.BookingStatus.Name,
        };

        PaymentForOtherDto? paymentDto = new()
        {
            Id = updatedBooking.Payment.Id,
        };

        return new BookingDto()
        {
            Id = updatedBooking.Id,
            User = userDto,
            Event = eventDto,
            BookingStatus = bookingStatusDto,
            NumberOfSeats = booking.NumberOfSeats,
            Payment = paymentDto,
            CreatedAt = updatedBooking.CreatedAt,
            UpdatedAt = updatedBooking.UpdatedAt,
        };
    }
    
    public async Task Delete(Guid id)
    {
        Booking? booking = await context.Bookings.FindAsync(id);
        context.Bookings.Remove(booking);
        await context.SaveChangesAsync();
    }
}