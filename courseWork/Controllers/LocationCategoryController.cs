using BLL.Interfaces;
using DTO.LocationCategory;
using Microsoft.AspNetCore.Mvc;

namespace courseWork.Controllers;

[ApiController]
[Route("locationCategories")]
public class LocationCategoryController(ILocationCategoryService locationCategoryService) : ControllerBase
{
    [HttpGet]
    [Route("GetAll")]
    public async Task<ActionResult<List<LocationCategoryDto>>> GetLocationCategories() => Ok(await locationCategoryService.GetLocationCategories());
    
    [HttpGet("{id}")]
    public async Task<ActionResult<LocationCategoryDto>> GetLocationCategory(Guid id) => Ok(await locationCategoryService.GetLocationCategory(id));

    [HttpPost]
    public async Task<ActionResult<LocationCategoryDto>> CreateLocationCategory([FromBody] CreateLocationCategoryDto locationCategory) => Ok(await locationCategoryService.CreateLocationCategory(locationCategory));

    [HttpPut("{id}")]
    public async Task<ActionResult<LocationCategoryDto>> UpdateLocationCategory(Guid id, [FromBody] UpdateLocationCategoryDto locationCategory)
    {
        locationCategory.Id = id;
       
        return Ok(await locationCategoryService.UpdateLocationCategory(locationCategory));
    }
    
    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteLocationCategory(Guid id)
    {
        await locationCategoryService.DeleteLocationCategory(id);
        return Ok();
    }
}