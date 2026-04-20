using DTO.EventCategory;

namespace DAL.Interfaces;

public interface IEventCategoryRepository:IRepository<EventCategoryDto,CreateEventCategoryDto,UpdateEventCategoryDto>
{
    
}