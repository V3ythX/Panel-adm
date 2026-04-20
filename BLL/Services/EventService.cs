using BLL.Interfaces;
using DAL.Interfaces;
using DTO.Event;
using DTO.Shared;

namespace BLL.Services;

public class EventService(IEventRepository eventRepository):IEventService
{
    public async Task<List<EventDto>> GetEvents() => await eventRepository.GetAll();
    public Task<ResponseWithFilterDto<EventDto>> GetEventsWithFilter(QueryParamsDto queryParams) => eventRepository.GetAllWithFilter(queryParams);
    public async Task<EventDto> GetEvent(Guid Id) => await eventRepository.GetById(Id);
    public async Task<EventDto> CreateEvent(CreateEventDto event1) => await eventRepository.Create(event1);
    public async Task<EventDto> UpdateEvent(UpdateEventDto event1) => await eventRepository.Update(event1);
    public async Task DeleteEvent(Guid Id) => await eventRepository.Delete(Id);
}