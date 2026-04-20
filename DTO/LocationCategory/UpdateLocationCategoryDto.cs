namespace DTO.LocationCategory;

public class UpdateLocationCategoryDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public List<Guid>LocationsIds { get; set; } = new();
}