using DAL.EF;
using DAL.Entities;
using DAL.Interfaces;
using DTO.Location;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories;

public class LocationRepository(ApplicationContext context) : ILocationRepository
{
    public async Task<List<LocationDto>> GetAll()
    {
        List<Location>locations = await context.Locations.ToListAsync();
        List<LocationDto> locationList = new List<LocationDto>();
        foreach (var location in locations)
        {
            LocationDto locationDto = new()
            {
                Id = location.Id,
                Name = location.Name,
                Address = location.Address,
                NumberOfSeats = location.NumberOfSeats,
                CreatedAt = location.CreatedAt,
                UpdatedAt = location.UpdatedAt,
            };
            locationList.Add(locationDto);
        }
        return locationList;
    }

    public async Task<LocationDto> GetById(Guid id)
    {
        Location? location = await context.Locations.FindAsync();
        return new LocationDto()
        {
            Id = location.Id,
            Name = location.Name,
            Address = location.Address,
            NumberOfSeats = location.NumberOfSeats,
            CreatedAt = location.CreatedAt,
            UpdatedAt = location.UpdatedAt,
        };
    }

    public async Task<LocationDto> Create(CreateLocationDto location)
    {
        Location createLocation = new()
        {
            Name = location.Name,
            Address = location.Address,
            NumberOfSeats = location.NumberOfSeats,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };
        context.Locations.Add(createLocation);
        await context.SaveChangesAsync();

        return new LocationDto()
        {
            Id = createLocation.Id,
            Name = createLocation.Name,
            Address = createLocation.Address,
            NumberOfSeats = createLocation.NumberOfSeats,
            CreatedAt = createLocation.CreatedAt,
            UpdatedAt = createLocation.UpdatedAt
        };
    }

    public async Task<LocationDto> Update(UpdateLocationDto location)
    {
        Location? updateLocation = await context.Locations.FindAsync(location.Id);
        updateLocation.Name = location.Name;
        updateLocation.Address = location.Address;
        updateLocation.NumberOfSeats = location.NumberOfSeats;
        updateLocation.UpdatedAt = DateTime.UtcNow;
        
        context.Locations.Update(updateLocation);
        await context.SaveChangesAsync();

        return new LocationDto()
        {
            Id = updateLocation.Id,
            Name = updateLocation.Name,
            Address = updateLocation.Address,
            NumberOfSeats = updateLocation.NumberOfSeats,
            CreatedAt = updateLocation.CreatedAt,
            UpdatedAt = updateLocation.UpdatedAt
        };
    }

    public async Task Delete(Guid id)
    {
        Location? location = await context.Locations.FindAsync(id);
        context.Locations.Remove(location);
        await context.SaveChangesAsync();
    }
    
}