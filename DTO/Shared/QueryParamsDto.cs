namespace DTO.Shared;

public class QueryParamsDto
{
    public string Offset { get; set; } = "0";
    public string Limit { get; set; } = "2";
    public string SortBy { get; set; } = "CreatedAt";
    public string OrderBy { get; set; } = "desc";
    public string Search { get; set; } = string.Empty;
    
    public bool IsAdmin { get; set; }
    
}