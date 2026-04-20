namespace DTO.LocationCategory;

public class CreateLocationCategoryDto
{
    public string Name { get; set; } = string.Empty;
    public List<Guid>LocationsIds { get; set; } = new();
}