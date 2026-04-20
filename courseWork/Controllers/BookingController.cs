using BLL.Interfaces;
using DTO.Booking;
using Microsoft.AspNetCore.Mvc;

namespace courseWork.Controllers;

[ApiController]
[Route("bookings")]
public class BookingController (
    IBookingService bookingService
) : ControllerBase
{
    [HttpGet]
    [Route("GetAll")]
    public async Task<ActionResult<List<BookingDto>>> GetBookings() => Ok(await bookingService.GetBookings());
    
    [HttpGet("{id}")]
    public async Task<ActionResult<BookingDto>> GetBooking(Guid id) => Ok(await bookingService.GetBooking(id));
    
    [HttpPost]
    public async Task<ActionResult<BookingDto>> CreateBooking([FromBody] CreateBookingDto booking) => Ok(await bookingService.CreateBooking(booking));
    
    [HttpPut("{id}")]
    public async Task<ActionResult<BookingDto>> UpdateBooking(Guid id, [FromBody] UpdateBookingDto booking)
    {
        booking.Id = id;
        
        return Ok(await bookingService.UpdateBooking(booking));
    }
    
    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(Guid id)
    {
        await bookingService.DeleteBooking(id);
        return Ok();
    }

}