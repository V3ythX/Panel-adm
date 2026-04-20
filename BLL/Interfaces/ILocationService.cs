using DAL.Entities;
using DTO.Location;

namespace BLL.Interfaces;

public interface ILocationService
{
    Task<List<LocationDto>> GetLocations();
    Task<LocationDto> GetLocation(Guid Id);
    Task<LocationDto> CreateLocation(CreateLocationDto location);
    Task<LocationDto> UpdateLocation(UpdateLocationDto location);
    Task DeleteLocation(Guid Id);
}