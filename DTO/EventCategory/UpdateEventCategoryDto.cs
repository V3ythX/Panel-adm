namespace DTO.EventCategory;

public class UpdateEventCategoryDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public List<Guid> EventsIds { get; set; } = new();
}