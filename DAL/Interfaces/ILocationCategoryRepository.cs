using DTO.LocationCategory;

namespace DAL.Interfaces;

public interface ILocationCategoryRepository:IRepository<LocationCategoryDto,CreateLocationCategoryDto,UpdateLocationCategoryDto>
{
    
}