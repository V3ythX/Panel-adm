using BLL.Interfaces;
using DTO.Location;
using Microsoft.AspNetCore.Mvc;

namespace courseWork.Controllers;

[ApiController]
[Route("locations")]
public class LocationController(ILocationService locationService):ControllerBase
{
    [HttpGet]
    [Route("GetAll")]
    public async Task<ActionResult<List<LocationDto>>> GetLocations() => Ok(await locationService.GetLocations());
    
    [HttpGet("{id}")]
    public async Task<ActionResult<LocationDto>> GetLocation(Guid id)=> Ok(await locationService.GetLocation(id));
    
    [HttpPost]
    public async Task<ActionResult<LocationDto>> CreateLocation([FromBody]CreateLocationDto location)=> Ok(await locationService.CreateLocation(location));
    
    [HttpPut("{id}")]
    public async Task<ActionResult<LocationDto>> UpdateLocation(Guid id, [FromBody] UpdateLocationDto location)
    {
        location.Id = id;
        
        return Ok(await locationService.UpdateLocation(location));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteLocation(Guid id)
    {
        await locationService.DeleteLocation(id);
        return Ok();
    }
}