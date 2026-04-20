using DTO.LocationCategory;

namespace BLL.Interfaces;

public interface ILocationCategoryService
{
    Task<List<LocationCategoryDto>> GetLocationCategories();
    Task<LocationCategoryDto> GetLocationCategory(Guid Id);
    Task<LocationCategoryDto> CreateLocationCategory(CreateLocationCategoryDto locationCategory);
    Task<LocationCategoryDto> UpdateLocationCategory(UpdateLocationCategoryDto locationCategory);
    Task DeleteLocationCategory(Guid Id);
}