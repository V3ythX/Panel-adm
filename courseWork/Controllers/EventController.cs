using BLL.Interfaces;
using DTO.Event;
using DTO.Shared;
using Microsoft.AspNetCore.Mvc;

namespace courseWork.Controllers;


[ApiController]
[Route("events")]
public class EventController(IEventService eventService):ControllerBase
{
    [HttpGet]
    [Route("GetAll")]
    public async Task<ActionResult<List<EventDto>>> GetEvents() => Ok(await eventService.GetEvents());
    
    [HttpGet]
    public async Task<ActionResult<ResponseWithFilterDto<EventDto>>> GetEventsWithFilter([FromQuery] QueryParamsDto queryParams)
    {
        var filteredEvents = await eventService.GetEventsWithFilter(queryParams);

        return Ok(filteredEvents);
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<EventDto>> GetEvent(Guid id) => Ok(await eventService.GetEvent(id));
    
    [HttpPost]
    public async Task<ActionResult<EventDto>> CreateEvent([FromBody] CreateEventDto event1) => Ok(await eventService.CreateEvent(event1));

    [HttpPut("{id}")]
    public async Task<ActionResult<EventDto>> UpdateEvent(Guid id, [FromBody] UpdateEventDto event1)
    {
        event1.Id = id;
        return Ok(await eventService.UpdateEvent(event1));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(Guid id)
    {
        await eventService.DeleteEvent(id);
        return Ok();
    }
}