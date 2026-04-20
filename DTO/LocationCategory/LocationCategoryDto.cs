using DTO.Location;

namespace DTO.LocationCategory;

public class LocationCategoryDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public List<LocationForOtherDto>Location { get; set; }
    
    public DateTime CreatedAt{ get; set; }
    public DateTime UpdatedAt{ get; set; }
}