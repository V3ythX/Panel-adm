using DAL.EF;
using DAL.Entities;
using DAL.Interfaces;
using DTO.LocationCategory;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories;

public class LocationCategoryRepository(ApplicationContext context): ILocationCategoryRepository
{
    public async Task<List<LocationCategoryDto>> GetAll()
    {
        List<LocationCategory> locationCategories = await context.LocationCategories.ToListAsync();
        List<LocationCategoryDto> locationCategoryList = new List<LocationCategoryDto>();
        foreach (var locationCategory in locationCategories)
        {
            LocationCategoryDto locationCategoryDto = new()
            {
                Id = locationCategory.Id,
                Name = locationCategory.Name,
                CreatedAt = locationCategory.CreatedAt,
                UpdatedAt = locationCategory.UpdatedAt,
            };
            locationCategoryList.Add(locationCategoryDto);
        }
        return locationCategoryList;
    }

    public async Task<LocationCategoryDto> GetById(Guid id)
    {
        LocationCategory? locationCategory = await context.LocationCategories.FindAsync();
        return new LocationCategoryDto()
        {
            Id = locationCategory.Id,
            Name = locationCategory.Name,
            CreatedAt = locationCategory.CreatedAt,
            UpdatedAt = locationCategory.UpdatedAt,
        };
    }

    public async Task<LocationCategoryDto> Create(CreateLocationCategoryDto locationCategory)
    {
        LocationCategory createlocationCategory = new()
        {
            Name = locationCategory.Name,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow,
        };
        context.LocationCategories.Add(createlocationCategory);
        await context.SaveChangesAsync();

        return new LocationCategoryDto()
        {
            Id = createlocationCategory.Id,
            Name = createlocationCategory.Name,
            CreatedAt = createlocationCategory.CreatedAt,
            UpdatedAt = createlocationCategory.UpdatedAt,
        };
    }

    public async Task<LocationCategoryDto> Update(UpdateLocationCategoryDto locationCategory)
    {
        LocationCategory? updatelocationCategory = await context.LocationCategories.FindAsync(locationCategory.Id);
        updatelocationCategory.Name = locationCategory.Name;
        updatelocationCategory.UpdatedAt = DateTime.UtcNow;
        
        context.LocationCategories.Update(updatelocationCategory);
        await context.SaveChangesAsync();

        return new LocationCategoryDto()
        {
            Id = updatelocationCategory.Id,
            Name = updatelocationCategory.Name,
            CreatedAt = updatelocationCategory.CreatedAt,
            UpdatedAt = updatelocationCategory.UpdatedAt,
        };
    }

    public async Task Delete(Guid id)
    {
        LocationCategory? locationCategory = await context.LocationCategories.FindAsync(id);
        context.LocationCategories.Remove(locationCategory);
        await context.SaveChangesAsync();
    }
}