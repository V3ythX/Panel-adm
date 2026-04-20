namespace DTO.Review;

public class ReviewForOtherDto
{
    public Guid Id { get; set; }
    public short Rating { get; set; }
    public string? Comment { get; set; } = string.Empty;
}