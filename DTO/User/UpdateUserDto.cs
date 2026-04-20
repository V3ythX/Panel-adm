namespace DTO.User;

public class UpdateUserDto
{
    public Guid Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string? Patronymic { get; set; } = string.Empty;
    public string Email { get; set; }
    public string Phone { get; set; } 
    public string Password { get; set; } 
    public bool IsAdmin { get; set; }

    public List<Guid> BookingsIds { get; set; } = new();
    public List<Guid> EventIds { get; set; } = new();
    public List<Guid> ReviewIds { get; set; } = new();
}