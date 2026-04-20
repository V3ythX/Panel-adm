using DTO.Event;
using DTO.Shared;

namespace BLL.Interfaces;

public interface IEventService
{
    Task<List<EventDto>> GetEvents();
    
    Task<ResponseWithFilterDto<EventDto>> GetEventsWithFilter(QueryParamsDto queryParams);
    Task<EventDto> GetEvent(Guid Id);
    Task<EventDto> CreateEvent(CreateEventDto event1);
    Task<EventDto> UpdateEvent(UpdateEventDto event1);
    Task DeleteEvent(Guid Id);
}