using DTO.EventCategory;

namespace BLL.Interfaces;

public interface IEventCategoryService
{
    Task<List<EventCategoryDto>> GetEventCategories();
    Task<EventCategoryDto> GetEventCategory(Guid Id);
    Task<EventCategoryDto> CreateEventCategory(CreateEventCategoryDto eventCategory);
    Task<EventCategoryDto> UpdateEventCategory(UpdateEventCategoryDto eventCategory);
    Task DeleteEventCategory(Guid Id);
}