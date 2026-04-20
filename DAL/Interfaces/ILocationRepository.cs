using DTO.Location;

namespace DAL.Interfaces;

public interface ILocationRepository:IRepository<LocationDto, CreateLocationDto, UpdateLocationDto>
{
    
}