using BLL.Interfaces;
using DAL.Interfaces;
using DTO.EventCategory;

namespace BLL.Services;

public class EventCategoryService(IEventCategoryRepository eventCategoryRepository):IEventCategoryService
{
    public async Task<List<EventCategoryDto>>GetEventCategories()=>await eventCategoryRepository.GetAll();
    public async Task<EventCategoryDto> GetEventCategory(Guid Id)=>await eventCategoryRepository.GetById(Id);
    public async Task<EventCategoryDto> CreateEventCategory(CreateEventCategoryDto eventCategory)=>await eventCategoryRepository.Create(eventCategory);
    public async Task<EventCategoryDto> UpdateEventCategory(UpdateEventCategoryDto eventCategory)=>await eventCategoryRepository.Update(eventCategory);
    public async Task DeleteEventCategory(Guid Id)=>await eventCategoryRepository.Delete(Id);
}