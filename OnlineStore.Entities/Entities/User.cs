namespace OnlineStore.Entities.Entities;

public class User
{
    public int Id { get; set; }
    public string? Username { get; set; }
    public string? Password { get; set; }
    public string? PasswordSalt { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public DateTime? BirthDate { get; set; }
    public bool IsActive { get; set; }
    public DateTime EntryDate { get; set; }
    public bool IsDeleted { get; set; }
}

