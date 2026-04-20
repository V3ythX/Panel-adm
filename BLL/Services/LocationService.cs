using BLL.Interfaces;
using DAL.Entities;
using DAL.Interfaces;
using DTO.Location;

namespace BLL.Services;

public class LocationService(ILocationRepository locationRepository) : ILocationService
{
    public async Task<List<LocationDto>> GetLocations() => await locationRepository.GetAll();
    public async Task<LocationDto> GetLocation(Guid Id) => await locationRepository.GetById(Id);
    public async Task<LocationDto> CreateLocation(CreateLocationDto location) => await locationRepository.Create(location);
    public async Task<LocationDto> UpdateLocation(UpdateLocationDto location)=> await locationRepository.Update(location);
    public async Task DeleteLocation(Guid Id) => await locationRepository.Delete(Id);
    
}