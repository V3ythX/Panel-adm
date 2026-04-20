namespace DTO.Location;

public class UpdateLocationDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Address { get; set; } = string.Empty;
    public int NumberOfSeats { get; set; }

    public List<Guid> EventsIds { get; set; } = new();
}