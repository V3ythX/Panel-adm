using System.Linq.Dynamic.Core;
using DAL.EF;
using DAL.Entities;
using DAL.Interfaces;
using DTO.Event;
using DTO.EventCategory;
using DTO.Location;
using DTO.Shared;
using DTO.User;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories;

public class EventRepository(ApplicationContext context): IEventRepository
{
    public async Task<List<EventDto>> GetAll()
    {
        List<Event> events = await context.Events
            .Include(e => e.Location)
            .Include(e => e.CreatedBy)
            .Include(e => e.EventCategory)
            .ToListAsync();
        List<EventDto> eventList = new List<EventDto>();

        foreach (var event1 in events)
        {
            LocationDto? locationDto = null;
            if (event1.Location != null)
            {
                locationDto = new LocationDto()
                {
                    Id = event1.Location.Id,
                    Name = event1.Location.Name,
                    Address = event1.Location.Address,
                    NumberOfSeats = event1.Location.NumberOfSeats,
                };
            }
            
           EventCategoryDto? eventCategoryDto = null;
           if (event1.EventCategory != null)
           {
               eventCategoryDto = new EventCategoryDto()
               {
                   Id = event1.EventCategory.Id,
                   Name = event1.EventCategory.Name,
               };
           }

           UserForOtherDto? userDto = null;
           if (event1.CreatedBy != null)
           {
               userDto = new UserForOtherDto()
               {
                   Id = event1.CreatedBy.Id,
                   FirstName = event1.CreatedBy.FirstName,
                   LastName = event1.CreatedBy.LastName,
                   Patronymic = event1.CreatedBy.Patronymic,
               };
           }

           EventDto eventDto = new()
           {
               Id = event1.Id,
               Title = event1.Title,
               Description = event1.Description,
               StartTime = event1.StartTime,
               EndTime = event1.EndTime,
               CreatedAt = event1.CreatedAt,
               UpdatedAt = event1.UpdatedAt,
               Location = locationDto,
               EventCategory = eventCategoryDto,
               User = userDto,
           };
           eventList.Add(eventDto);
        }
        return eventList;
    }
    
    public async Task<ResponseWithFilterDto<EventDto>> GetAllWithFilter(QueryParamsDto queryParams)
    {
        int offset = int.Parse(queryParams.Offset);
        int limit = int.Parse(queryParams.Limit);
        string sorting = $"{queryParams.SortBy} {(queryParams.OrderBy?.ToLower() == "desc" ? "descending" : "ascending")}";
        var events = context
            .Events.AsQueryable();

        if (queryParams.Search != string.Empty)
        {
            events = events
                .Where(e => 
                    e.Title.ToLower().Contains(queryParams.Search.ToLower())
                    || e.Description.ToLower().Contains(queryParams.Search.ToLower())
                );
        }
        
        int TotalEvents = await events.CountAsync();

        var eventsList = events
            .OrderBy(sorting)
            .Skip(offset * limit)
            .Take(limit)
            .Select(e => new EventDto()
            {
                Id = e.Id,
                Title = e.Title,
                Description = e.Description,
                CreatedAt = e.CreatedAt,
                UpdatedAt = e.UpdatedAt
            })
            .ToList();

        return new ResponseWithFilterDto<EventDto>(
            eventsList,
            queryParams.Offset,
            queryParams.Limit,
            TotalEvents
        );
    }

    public async Task<EventDto> GetById(Guid id)
    {
        Event? event1 = await context.Events.FindAsync(id);
        
        
        UserForOtherDto? userDto = null;
        if (event1.CreatedBy != null)
        {
            userDto = new UserForOtherDto()
            {
                Id = event1.CreatedBy.Id,
                FirstName = event1.CreatedBy.FirstName,
                LastName = event1.CreatedBy.LastName,
                Patronymic = event1.CreatedBy.Patronymic,
            };
        }
        EventCategoryDto? eventCategoryDto = null;
        if (event1.EventCategory != null)
        {
            eventCategoryDto = new EventCategoryDto()
            {
                Id = event1.EventCategory.Id,
                Name = event1.EventCategory.Name,
            };
        }

        LocationDto? locationDto = null;
        if (event1.Location != null)
        {
            locationDto = new LocationDto()
            {
                Id = event1.Location.Id,
                Name = event1.Location.Name,
                Address = event1.Location.Address,
                NumberOfSeats = event1.Location.NumberOfSeats,
            };
        }

        return new EventDto()
        {
            Id = event1.Id,
            Title = event1.Title,
            Description = event1.Description,
            StartTime = event1.StartTime,
            EndTime = event1.EndTime,
            Location = locationDto,
            EventCategory = eventCategoryDto,
            User = userDto,
            CreatedAt = event1.CreatedAt,
            UpdatedAt = event1.UpdatedAt,
        };
    }
    public async Task<EventDto> Create(CreateEventDto event1){
        Location? location = await context.Locations
            .FirstOrDefaultAsync(l => l.Id == event1.LocationId);
        EventCategory? eventCategory = await context.EventCategories
            .FirstOrDefaultAsync(e => e.Id == event1.EventCategoryId);
        User? user = await context.Users
            .FirstOrDefaultAsync(u => u.Id == event1.UserId);

        Event createEvent = new()
        {
            Location = location,
            EventCategory = eventCategory,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow,
            Title = event1.Title,
            Description = event1.Description,
            StartTime = event1.StartTime,
            EndTime = event1.EndTime,
            CreatedBy = user,
        };
        context.Events.Add(createEvent);
        await context.SaveChangesAsync();

        UserForOtherDto? userDto = new()
        {
            Id = createEvent.CreatedBy.Id,
            FirstName = createEvent.CreatedBy.FirstName,
            LastName = createEvent.CreatedBy.LastName,
            Patronymic = createEvent.CreatedBy.Patronymic,
        };

        EventCategoryDto? eventCategoryDto = new()
        {
            Id = eventCategory.Id,
            Name = eventCategory.Name,
        };

        LocationDto? locationDto = new()
        {
            Id = location.Id,
            Name = location.Name,
            Address = location.Address,
            NumberOfSeats = location.NumberOfSeats,
        };
        return new EventDto()
        {
            Id = createEvent.Id,
            Title = createEvent.Title,
            Description = createEvent.Description,
            StartTime = createEvent.StartTime,
            EndTime = createEvent.EndTime,
            Location = locationDto,
            EventCategory = eventCategoryDto,
            User = userDto,
            CreatedAt = createEvent.CreatedAt,
            UpdatedAt = createEvent.UpdatedAt,
        };
    }

    public async Task<EventDto> Update(UpdateEventDto event1)
    {
        Event? updateEvent = await context.Events.FindAsync(event1.Id);
        
        
        User? user = await context.Users
            .FirstOrDefaultAsync(u => u.Id == event1.UserId);
        EventCategory? eventCategory = await context.EventCategories
            .FirstOrDefaultAsync(e => e.Id == event1.EventCategoryId);
        Location? location = await context.Locations
            .FirstOrDefaultAsync(l => l.Id == event1.LocationId);
        
        updateEvent.Title = event1.Title;
        updateEvent.Description = event1.Description;
        updateEvent.StartTime = event1.StartTime;
        updateEvent.EndTime = event1.EndTime;
        updateEvent.Location = location;
        updateEvent.EventCategory = eventCategory;
        updateEvent.CreatedBy = user;
        updateEvent.UpdatedAt = DateTime.UtcNow;
        
        context.Events.Update(updateEvent);
        await context.SaveChangesAsync();

        UserForOtherDto? userDto = new()
        {
            Id = updateEvent.CreatedBy.Id,
            FirstName = updateEvent.CreatedBy.FirstName,
            LastName = updateEvent.CreatedBy.LastName,
            Patronymic = updateEvent.CreatedBy.Patronymic,
        };

        EventCategoryDto? eventCategoryDto = new()
        {
            Id = eventCategory.Id,
            Name = eventCategory.Name,
        };

        LocationDto? locationDto = new()
        {
            Id = location.Id,
            Name = location.Name,
            Address = location.Address,
            NumberOfSeats = location.NumberOfSeats,
        };
        return new EventDto()
        {
            Id = updateEvent.Id,
            Title = updateEvent.Title,
            Description = updateEvent.Description,
            StartTime = updateEvent.StartTime,
            EndTime = updateEvent.EndTime,
            Location = locationDto,
            EventCategory = eventCategoryDto,
            User = userDto,
            CreatedAt = updateEvent.CreatedAt,
            UpdatedAt = updateEvent.UpdatedAt,
        };
    }

    public async Task Delete(Guid id)
    {
        Event? event1 = await context.Events.FindAsync(id);
        context.Events.Remove(event1);
        await context.SaveChangesAsync();
    }
}