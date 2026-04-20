using DTO.Event;
using DTO.Shared;

namespace DAL.Interfaces;

public interface IEventRepository:IRepository<EventDto,CreateEventDto,UpdateEventDto>
{
    Task<ResponseWithFilterDto<EventDto>> GetAllWithFilter(QueryParamsDto queryParams);
    
}