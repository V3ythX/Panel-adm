using BLL.Interfaces;
using DAL.Interfaces;
using DTO.LocationCategory;

namespace BLL.Services;

public class LocationCategoryService(ILocationCategoryRepository locationCategoryRepository): ILocationCategoryService
{
    public async Task<List<LocationCategoryDto>> GetLocationCategories() => await locationCategoryRepository.GetAll();
    public async Task<LocationCategoryDto> GetLocationCategory(Guid Id)=> await locationCategoryRepository.GetById(Id);
    public async Task<LocationCategoryDto> CreateLocationCategory(CreateLocationCategoryDto locationCategory)=> await locationCategoryRepository.Create(locationCategory);
    public async Task<LocationCategoryDto> UpdateLocationCategory(UpdateLocationCategoryDto locationCategory)=> await locationCategoryRepository.Update(locationCategory);
    public async Task DeleteLocationCategory(Guid Id) => await locationCategoryRepository.Delete(Id);
}