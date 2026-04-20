namespace DTO.EventCategory;

public class CreateEventCategoryDto
{
    public string Name { get; set; } = string.Empty;
    public List<Guid> EventsIds { get; set; } = new();
}