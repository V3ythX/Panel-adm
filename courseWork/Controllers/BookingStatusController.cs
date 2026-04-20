using BLL.Interfaces;
using DTO.BookingStatus;
using Microsoft.AspNetCore.Mvc;

namespace courseWork.Controllers;

[ApiController]
[Route("bookingStatuses")]
public class BookingStatusController(IBookingStatusService bookingStatusService):ControllerBase
{
    [HttpGet]
    [Route("GetAll")]
    public async Task<ActionResult<List<BookingStatusDto>>> GetBookingStatuses() => Ok(await bookingStatusService.GetBookingStatuses());
    
    [HttpGet("{id}")]
    public async Task<ActionResult<BookingStatusDto>> GetBookingStatus(Guid id)=> Ok(await bookingStatusService.GetBookingStatus(id));
    
    [HttpPost]
    public async Task<ActionResult<BookingStatusDto>> CreateBookingStatus([FromBody]CreateBookingStatusDto bookingStatus)=> Ok(await bookingStatusService.CreateBookingStatus(bookingStatus));
    
    [HttpPut("{id}")]
    public async Task<ActionResult<BookingStatusDto>> UpdateBookingStatus(Guid id, [FromBody] UpdateBookingStatusDto bookingStatus)
    {
        bookingStatus.Id = id;
        return Ok(await bookingStatusService.UpdateBookingStatus(bookingStatus));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteBookingStatus(Guid id)
    {
        await bookingStatusService.DeleteBookingStatus(id);
        return Ok();
    }
    
}