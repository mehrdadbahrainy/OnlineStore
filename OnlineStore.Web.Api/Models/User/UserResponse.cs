namespace OnlineStore.Web.Api.Models.user;

public class UserResponse
{
    public UserResponse(Entities.Entities.User user)
    {
        Id = user.Id;
        Username = user.Username;
        Email = user.Email;
        FirstName = user.FirstName;
        LastName = user.LastName;
        BirthDate = user.BirthDate;
        IsActive = user.IsActive;
        EntryDate = user.EntryDate;
    }

    public int Id { get; set; }
    public string? Username { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public DateTime? BirthDate { get; set; }
    public bool IsActive { get; set; }
    public DateTime EntryDate { get; set; }
}