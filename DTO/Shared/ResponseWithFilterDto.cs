namespace DTO.Shared;

public class ResponseWithFilterDto<T>
{
    public List<T> Data { get; set; } = new();
    public int CurrentPage { get; set; }
    public int TotalPages { get; set; }
    public int TotalItems { get; set; }

    public ResponseWithFilterDto
        (
            List<T> data,
            string offset,
            string limit,
            int totalItems
        )
    {
        Data = data;
        CurrentPage = int.Parse(offset) + 1;
        TotalPages = (int)Math.Ceiling(totalItems / double.Parse(limit));
        TotalItems = totalItems;
    }
}