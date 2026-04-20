namespace DTO.Review;

public class UpdateReviewDto
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid? EventId { get; set; }
    public string? Comment { get; set; } = string.Empty;
    public short Rating { get; set; }
}