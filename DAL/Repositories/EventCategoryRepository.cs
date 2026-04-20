using DAL.EF;
using DAL.Entities;
using DAL.Interfaces;
using DTO.EventCategory;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories;

public class EventCategoryRepository(ApplicationContext context) : IEventCategoryRepository
{
    public async Task<List<EventCategoryDto>> GetAll()
    {
        List<EventCategory>eventCategories = await context.EventCategories.ToListAsync();
        List<EventCategoryDto> eventCategoriesList = new List<EventCategoryDto>();
        foreach (var eventCategory in eventCategories)
        {
            EventCategoryDto eventCategoryDto = new()
            {
                Id = eventCategory.Id,
                Name = eventCategory.Name,
                CreatedAt = eventCategory.CreatedAt,
                UpdatedAt = eventCategory.UpdatedAt,
            };
            eventCategoriesList.Add(eventCategoryDto);
        }
        return eventCategoriesList;
    }

    public async Task<EventCategoryDto> GetById(Guid id)
    {
        EventCategory? eventCategory = await context.EventCategories.FindAsync();
        return new EventCategoryDto()
        {
            Id = eventCategory.Id,
            Name = eventCategory.Name,
            CreatedAt = eventCategory.CreatedAt,
            UpdatedAt = eventCategory.UpdatedAt,
        };
    }

    public async Task<EventCategoryDto> Create(CreateEventCategoryDto eventCategory)
    {
        EventCategory createeventCategory = new()
        {
            Name = eventCategory.Name,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow,
        };
        context.EventCategories.Add(createeventCategory);
        await context.SaveChangesAsync();

        return new EventCategoryDto()
        {
            Id = createeventCategory.Id,
            Name = createeventCategory.Name,
            CreatedAt = createeventCategory.CreatedAt,
            UpdatedAt = createeventCategory.UpdatedAt,
        };
    }

    public async Task<EventCategoryDto> Update(UpdateEventCategoryDto eventCategory)
    {
        EventCategory? updateeventCategory = await context.EventCategories.FindAsync(eventCategory.Id);
        updateeventCategory.Name = eventCategory.Name;
        updateeventCategory.UpdatedAt = DateTime.UtcNow;
        
        context.EventCategories.Update(updateeventCategory);
        await context.SaveChangesAsync();

        return new EventCategoryDto()
        {
            Id = updateeventCategory.Id,
            Name = updateeventCategory.Name,
            CreatedAt = updateeventCategory.CreatedAt,
            UpdatedAt = updateeventCategory.UpdatedAt,
        };
    }

    public async Task Delete(Guid id)
    {
        EventCategory? eventCategory = await context.EventCategories.FindAsync(id);
        context.EventCategories.Remove(eventCategory);
        await context.SaveChangesAsync();
    }
}