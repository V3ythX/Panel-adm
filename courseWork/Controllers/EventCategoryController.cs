using BLL.Interfaces;
using DTO.EventCategory;
using Microsoft.AspNetCore.Mvc;

namespace courseWork.Controllers;
[ApiController]
[Route("eventCategories")]
public class EventCategoryController(IEventCategoryService eventCategoryService) : ControllerBase
{
    [HttpGet]
    [Route("GetAll")]
    public async Task<ActionResult<List<EventCategoryDto>>> GetEventCategories() => Ok(await eventCategoryService.GetEventCategories());
    
    [HttpGet("{id}")]
    public async Task<ActionResult<EventCategoryDto>> GetEventCategory(Guid id) => Ok(await eventCategoryService.GetEventCategory(id));

    [HttpPost]
    public async Task<ActionResult<EventCategoryDto>> CreateEventCategory([FromBody] CreateEventCategoryDto eventCategory) => Ok(await eventCategoryService.CreateEventCategory(eventCategory));

    [HttpPut("{id}")]
    public async Task<ActionResult<EventCategoryDto>> UpdateEventCategory(Guid id, [FromBody] UpdateEventCategoryDto eventCategory)
    {
       eventCategory.Id = id;
       
       return Ok(await eventCategoryService.UpdateEventCategory(eventCategory));
    }
    
    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteEventCategory(Guid id)
    {
        await eventCategoryService.DeleteEventCategory(id);
        return Ok();
    }
}